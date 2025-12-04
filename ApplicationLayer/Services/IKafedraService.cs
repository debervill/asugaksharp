using asugaksharp.Core.Entities;

namespace asugaksharp.ApplicationLayer.Services
{
    public interface IKafedraService
    {
        Task<Kafedra?> GetByIdAsync(Guid id);
        Task<IEnumerable<Kafedra>> GetAllAsync();
        Task<Kafedra> AddAsync(Kafedra kafedra);
        Task UpdateAsync(Kafedra kafedra);
        Task DeleteAsync(Guid id);
        Task<Kafedra?> GetByNameAsync(string name);
        Task<IEnumerable<Kafedra>> GetKafedrasWithPersonsAsync();
    }
}