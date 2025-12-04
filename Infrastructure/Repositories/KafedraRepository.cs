using asugaksharp.Core.Entities;
using asugaksharp.Core.Interfaces;
using asugaksharp.Infrastructure.Persistanse;


namespace asugaksharp.Infrastructure.Repositories
{
    public class KafedraRepository : IKafedraRepository
    {
        private readonly AppDbContext _context;

        public KafedraRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Kafedra> AddAsync(Kafedra entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Kafedra>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Kafedra?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Kafedra?> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Kafedra>> GetKafedrasWithPersonsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Kafedra entity)
        {
            throw new NotImplementedException();
        }

        // ... остальные методы
    }
}
