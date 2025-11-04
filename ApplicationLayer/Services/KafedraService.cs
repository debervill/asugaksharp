/*
using asugaksharp.ApplicationLayer.Interface;
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

        public Task<List<string>> GetAllNamesAsync()
        {
            throw new NotImplementedException();
        }


        /*
    public async Task<List<string>> GetAllNamesAsync()
    {
        return await _context.Kafedra
            .Select(k => k.Name)
            .ToListAsync();

        
    }
    }
}
*/