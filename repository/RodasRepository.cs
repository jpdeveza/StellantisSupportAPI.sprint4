using StellantisSupportAPI.Data;
using StellantisSupportAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StellantisSupportAPI.repository
{
    public class RodasRepository
    {
        private readonly CarroContext _context;

        public RodasRepository(CarroContext context)
        {
            _context = context;
        }

        public async Task<Rodas> CreateRodas(Rodas rodas)
        {
            _context.Rodas.Add(rodas);
            await _context.SaveChangesAsync();
            return rodas;
        }

        public async Task<IEnumerable<Rodas>> GetRodas()
        {
            return await _context.Rodas.ToListAsync();
        }

        public async Task<Rodas> GetRodasById(int id)
        {
            return await _context.Rodas.FindAsync(id);
        }

        public async Task<Rodas> UpdateRodas(Rodas rodas)
        {
            _context.Rodas.Update(rodas);
            await _context.SaveChangesAsync();
            return rodas;
        }

        public async Task<bool> DeleteRodas(int id)
        {
            var rodas = await _context.Rodas.FindAsync(id);
            if (rodas == null)
            {
                return false;
            }

            _context.Rodas.Remove(rodas);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
