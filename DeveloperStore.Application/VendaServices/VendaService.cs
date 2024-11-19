using DeveloperStore.Application.DTOs;
using DeveloperStore.Application.Interfaces;
using DeveloperStore.Application.Utils;
using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.VendaServices
{
    public class VendaService: IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<VendaDTO> GetVendaByIdAsync(Guid id)
        {
            var venda = await _vendaRepository.GetByIdAsync(id);
            if (venda == null) throw new Exception("Venda não encontrada.");
            return new VendaDTO
            {
                NumeroVenda = venda.NumeroVenda,
                DataVenda = venda.DataVenda,
                Cliente = venda.Cliente,
                ValorTotal = venda.ValorTotal,
                Filial = venda.Filial,
                Cancelado = venda.Cancelado,
                Itens = venda.Itens.Select(item => new ItemVendaDTO
                {
                    Produto = item.Produto,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario,
                    Desconto = item.Desconto,
                    ValorTotal = item.ValorTotal,
                    Cancelado = item.Cancelado
                }).ToList()
            };
        }


        public async Task<VendaDTO> CreateVendaAsync(VendaDTO vendaDto)
        {
            // Validação de quantidade máxima de itens (máximo de 20 por produto)
            foreach (var item in vendaDto.Itens)
            {
                item.ValidarQuantidade();// Validando a quantidade
                item.AplicarDesconto(); // Aplica o desconto com base na quantidade
                item.CalcularValorTotal(); // Calcula o valor total do item com o desconto
            }

            // Calculando o valor total da venda
            vendaDto.CalcularValorTotalVenda();

            var venda = new Venda
            {
                NumeroVenda = Guid.NewGuid().ToString(),
                DataVenda = vendaDto.DataVenda,
                Cliente = vendaDto.Cliente,
                ValorTotal = vendaDto.ValorTotal,
                Filial = vendaDto.Filial,
                Cancelado = vendaDto.Cancelado,
                Itens = vendaDto.Itens.Select(item => new ItemVenda
                {
                    Produto = item.Produto,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario,
                    Desconto = item.Desconto,
                    ValorTotal = item.ValorTotal,
                    Cancelado = item.Cancelado
                }).ToList()
            };

            await _vendaRepository.AddAsync(venda);

            // Logando o evento de venda criada
            EventLogger.LogEvent($"Venda criada: {venda.NumeroVenda}");
            return vendaDto;
        }


        public async Task<VendaDTO?> UpdateVendaAsync(Guid id, VendaDTO vendaDto)
        {
            var venda = await _vendaRepository.GetByIdAsync(id);
            if (venda == null) return null;

            venda.DataVenda = vendaDto.DataVenda;
            venda.Cliente = vendaDto.Cliente;
            venda.Filial = vendaDto.Filial;
            venda.ValorTotal = vendaDto.ValorTotal;
            venda.Cancelado = vendaDto.Cancelado;

            await _vendaRepository.UpdateAsync(venda);

            // Logando o evento de venda modificada
            EventLogger.LogEvent($"Venda modificada: {venda.NumeroVenda}");

            return vendaDto;
        }

        public async Task<bool> DeleteVendaAsync(Guid id)
        {
            var venda = await _vendaRepository.GetByIdAsync(id);
            if (venda == null) return false;

            await _vendaRepository.DeleteAsync(venda.Id);

            // Logando o evento de venda cancelada
            EventLogger.LogEvent($"Venda cancelada: {venda.NumeroVenda}");

            return true;
        }
    }
}