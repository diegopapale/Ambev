using DeveloperStore.Domain.Entities;
using DeveloperStore.Domain.Repositories;
using DeveloperStore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Infrastructure.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VendaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Venda venda)
        {
            await _dbContext.Vendas.AddAsync(venda);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var venda = await GetByIdAsync(id);
            if (venda != null)
            {
                _dbContext.Vendas.Remove(venda);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Venda>> GetAllAsync()
        {
            return await _dbContext.Vendas.Include(v => v.Itens).ToListAsync();
        }

        public async Task<Venda> GetByIdAsync(Guid id)
        {
            return await _dbContext.Vendas.Include(v => v.Itens).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task UpdateAsync(Venda venda)
        {
            _dbContext.Vendas.Update(venda);
            await _dbContext.SaveChangesAsync();
        }
    }
}
