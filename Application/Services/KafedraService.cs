using asugaksharp.Core.Entities;
using asugaksharp.Infrastructure.Persistanse;
using Microsoft.EntityFrameworkCore;

namespace asugaksharp.ApplicationLayer.Services
{
    public class KafedraService : IKafedraService
    {
        private readonly AppDbContext _context;

        public KafedraService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Kafedra?> GetByIdAsync(Guid id)
        {
            return await _context.Kafedras
                .Include(k => k.Persons)
                .Include(k => k.Gaks)
                .Include(k => k.Periods)
                .FirstOrDefaultAsync(k => k.Id == id);
        }

        public async Task<IEnumerable<Kafedra>> GetAllAsync()
        {
            return await _context.Kafedras
                .Include(k => k.Persons)
                .Include(k => k.Gaks)
                .OrderBy(k => k.Name)
                .ToListAsync();
        }

        public async Task<Kafedra> AddAsync(Kafedra kafedra)
        {
            _context.Kafedras.Add(kafedra);
            await _context.SaveChangesAsync();
            return kafedra;
        }

        public async Task UpdateAsync(Kafedra kafedra)
        {
            _context.Kafedras.Update(kafedra);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var kafedra = await _context.Kafedras.FindAsync(id);
            if (kafedra != null)
            {
                _context.Kafedras.Remove(kafedra);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Kafedra?> GetByNameAsync(string name)
        {
            return await _context.Kafedras
                .FirstOrDefaultAsync(k => k.Name == name);
        }

        public async Task<IEnumerable<Kafedra>> GetKafedrasWithPersonsAsync()
        {
            return await _context.Kafedras
                .Include(k => k.Persons)
                .Include(k => k.Gaks)
                .Include(k => k.Periods)
                .OrderBy(k => k.Name)
                .ToListAsync();
        }
    }
}