using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Person;

public class GetPersonsHandler
{
    private readonly AppDbContext _context;
    public GetPersonsHandler(AppDbContext context) => _context = context;

    public async Task<List<PersonDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.Person
            .AsNoTracking()
            .Include(p => p.Kafedra)
            .OrderBy(p => p.Name)
            .Select(p => new PersonDto(
                p.Id,
                p.Name,
                p.Stepen,
                p.Zvanie,
                p.Dolgnost,
                p.IsPredsed,
                p.IsZavKaf,
                p.IsSecretar,
                p.IsRecenzent,
                p.IsVneshniy,
                p.KafedraID,
                p.Kafedra != null ? p.Kafedra.Name : null))
            .ToListAsync(ct);
    }
}
