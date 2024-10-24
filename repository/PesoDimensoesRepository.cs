using StellantisSupportAPI.Data;
using StellantisSupportAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StellantisSupportAPI.repository
{
    public class PesoDimensoesRepository
    {
        private readonly CarroContext _context;

        public PesoDimensoesRepository(CarroContext context)
        {
            _context = context;
        }

        public async Task<PesoDimensoes> CreatePesoDimensoes(PesoDimensoes pesoDimensoes)
        {
            _context.PesoDimensoes.Add(pesoDimensoes);
            await _context.SaveChangesAsync();
            return pesoDimensoes;
        }

        public async Task<IEnumerable<PesoDimensoes>> GetPesoDimensoes()
        {
            return await _context.PesoDimensoes.ToListAsync();
        }

        public async Task<PesoDimensoes> GetPesoDimensoesById(int id)
        {
            return await _context.PesoDimensoes.FindAsync(id);
        }

        public async Task<PesoDimensoes> UpdatePesoDimensoes(PesoDimensoes pesoDimensoes)
        {
            _context.PesoDimensoes.Update(pesoDimensoes);
            await _context.SaveChangesAsync();
            return pesoDimensoes;
        }

        public async Task<bool> DeletePesoDimensoes(int id)
        {
            var pesoDimensoes = await _context.PesoDimensoes.FindAsync(id);
            if (pesoDimensoes == null)
            {
                return false;
            }

            _context.PesoDimensoes.Remove(pesoDimensoes);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
