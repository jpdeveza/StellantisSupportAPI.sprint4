using StellantisSupportAPI.Data;
using StellantisSupportAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StellantisSupportAPI.repository
{
    public class ConsumoDesempenhoRepository
    {
        private readonly CarroContext _context;

        public ConsumoDesempenhoRepository(CarroContext context)
        {
            _context = context;
        }

        public async Task<ConsumoDesempenho> CreateConsumoDesempenho(ConsumoDesempenho consumoDesempenho)
        {
            _context.ConsumoDesempenhos.Add(consumoDesempenho);
            await _context.SaveChangesAsync();
            return consumoDesempenho;
        }

        public async Task<IEnumerable<ConsumoDesempenho>> GetConsumoDesempenhos()
        {
            return await _context.ConsumoDesempenhos.ToListAsync();
        }

        public async Task<ConsumoDesempenho> GetConsumoDesempenhoById(int id)
        {
            return await _context.ConsumoDesempenhos.FindAsync(id);
        }

        public async Task<ConsumoDesempenho> UpdateConsumoDesempenho(ConsumoDesempenho consumoDesempenho)
        {
            _context.ConsumoDesempenhos.Update(consumoDesempenho);
            await _context.SaveChangesAsync();
            return consumoDesempenho;
        }

        public async Task<bool> DeleteConsumoDesempenho(int id)
        {
            var consumoDesempenho = await _context.ConsumoDesempenhos.FindAsync(id);
            if (consumoDesempenho == null)
            {
                return false;
            }

            _context.ConsumoDesempenhos.Remove(consumoDesempenho);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
