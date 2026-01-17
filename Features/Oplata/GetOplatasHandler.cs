using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Oplata;

public class GetOplatasHandler
{
    private readonly AppDbContext _context;
    public GetOplatasHandler(AppDbContext context) => _context = context;

    public async Task<List<OplataDto>> ExecuteAsync(CancellationToken ct = default)
    {
        return await _context.Oplata
            .AsNoTracking()
            .Include(o => o.Person)
            .OrderBy(o => o.Person != null ? o.Person.Name : "")
            .Select(o => new OplataDto(
                o.Id,
                o.Stavka,
                o.Ndfl,
                o.Enp,
                o.MoneySource,
                o.DogovorNumber,
                o.PersonId,
                o.Person != null ? o.Person.Name : null))
            .ToListAsync(ct);
    }
}
