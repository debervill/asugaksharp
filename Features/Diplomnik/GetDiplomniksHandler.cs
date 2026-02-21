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
            .Include(d => d.Student)
            .ThenInclude(s => s.Person)
            .Include(d => d.Zasedanie)
            .OrderBy(d => d.Student != null ? d.Student.FioImen : string.Empty)
            .Select(d => new DiplomnikDto(
                d.Id,
                d.StudentId,
                d.Student != null ? d.Student.FioImen : string.Empty,
                d.Student != null ? d.Student.FioRodit : string.Empty,
                d.Student != null ? d.Student.Sex : string.Empty,
                d.Student != null ? d.Student.Pages : 0,
                d.Student != null ? d.Student.Tema : string.Empty,
                d.Student != null ? d.Student.OrigVkr : 0,
                d.Student != null ? d.Student.Srball : 0,
                d.Student != null ? d.Student.PersonId : Guid.Empty,
                d.Student != null && d.Student.Person != null ? d.Student.Person.Name : null,
                d.ZasedanieId,
                d.Zasedanie != null ? $"{d.Zasedanie.NapravleniePodgotovki} ({d.Zasedanie.Date:dd.MM.yyyy})" : null))
            .ToListAsync(ct);
    }
}
