using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Diplomnik;

public class GetDiplomniksHandler
{
    private readonly AppDbContext _context;
    public GetDiplomniksHandler(AppDbContext context) => _context = context;

    public async Task<List<DiplomnikDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.Diplomnik
            .AsNoTracking()
            .Include(d => d.Person)
            .OrderBy(d => d.FioImen)
            .Select(d => new DiplomnikDto(
                d.Id,
                d.FioImen,
                d.FioRodit,
                d.Sex,
                d.Pages,
                d.Tema,
                d.OrigVkr,
                d.Srball,
                d.PersonId,
                d.Person != null ? d.Person.Name : null))
            .ToListAsync(ct);
    }
}
