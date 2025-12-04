using asugaksharp.Core.Entities;


namespace asugaksharp.Core.Interfaces
{
    public interface IKafedraRepository : IRepository<Kafedra>
    {
        Task<Kafedra?> GetByNameAsync(string name);
        Task<IEnumerable<Kafedra>> GetKafedrasWithPersonsAsync();
        Task AddKafedraAsync(Kafedra kafedra);
        Task UpdateKafedraAsync(Kafedra kafedra);

        Task DeleteKafedraAsync(string id);
    }
}