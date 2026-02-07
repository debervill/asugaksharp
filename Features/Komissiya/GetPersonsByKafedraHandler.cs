using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Komissiya;

public class GetPersonsByKafedraHandler
{
    private readonly AppDbContext _context;
    public GetPersonsByKafedraHandler(AppDbContext context) => _context = context;

    public async Task<List<KomissiyaPersonDto>> ExecuteAsync(Guid kafedraId, CancellationToken ct = default)
    {
        return await _context.Person
            .AsNoTracking()
            .Where(p => p.KafedraID == kafedraId)
            .OrderBy(p => p.Name)
            .Select(p => new KomissiyaPersonDto(
                p.Id,
                p.Name,
                p.Stepen,
                p.Zvanie,
                p.Dolgnost,
                p.IsPredsed,
                p.IsSecretar))
            .ToListAsync(ct);
    }
}
