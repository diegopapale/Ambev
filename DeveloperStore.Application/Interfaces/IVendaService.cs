using DeveloperStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Application.Interfaces
{
    public interface IVendaService
    {
        Task<VendaDTO> GetVendaByIdAsync(Guid id);
        Task<VendaDTO> CreateVendaAsync(VendaDTO vendaDto);
        Task<VendaDTO?> UpdateVendaAsync(Guid id, VendaDTO vendaDto);
        Task<bool> DeleteVendaAsync(Guid id);
    }
}
