using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.DTOs
{
    public class ItemVendaDTO
    {
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Cancelado { get; set; }


        // Valida a quantidade
        public void ValidarQuantidade()
        {
            if (Quantidade > 20)
                throw new InvalidOperationException("Não é permitido mais de 20 itens de um mesmo produto.");
        }

        // Cálculo do valor total do item
        public void CalcularValorTotal()
        {
            // Aplica o desconto, se necessário
            ValorTotal = Quantidade * PrecoUnitario * (1 - Desconto / 100);
        }

        // Cálculo de desconto baseado nas quantidades
        public void AplicarDesconto()
        {
            if (Quantidade >= 4 && Quantidade < 10)
                Desconto = 10; // 10% de desconto
            else if (Quantidade >= 10 && Quantidade <= 20)
                Desconto = 20; // 20% de desconto
            else
                Desconto = 0; // Nenhum desconto
        }
    }

    public class VendaDTO
    {
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public string Cliente { get; set; }
        public decimal ValorTotal { get; set; }
        public string Filial { get; set; }
        public bool Cancelado { get; set; }
        public List<ItemVendaDTO> Itens { get; set; }

        // Calculando o valor total da venda
        public void CalcularValorTotalVenda()
        {
            ValorTotal = Itens.Sum(item => item.ValorTotal);
        }
    }



}
