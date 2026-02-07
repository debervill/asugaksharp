using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Oplata;

public class GetGakExternalMembersHandler
{
    private readonly AppDbContext _context;
    public GetGakExternalMembersHandler(AppDbContext context) => _context = context;

    public async Task<List<OplataRowDto>> ExecuteAsync(Guid gakId, CancellationToken ct = default)
    {
        var gak = await _context.Gak
            .AsNoTracking()
            .Include(g => g.Predsedatel)
            .Include(g => g.Sekretar)
            .Include(g => g.Persons)
            .FirstOrDefaultAsync(g => g.Id == gakId, ct);

        if (gak == null)
            return new List<OplataRowDto>();

        var result = new List<OplataRowDto>();

        // Председатель (если внешний)
        if (gak.Predsedatel != null && gak.Predsedatel.IsVneshniy)
        {
            result.Add(new OplataRowDto
            {
                PersonId = gak.Predsedatel.Id,
                PersonName = gak.Predsedatel.Name,
                RolVGek = "Председатель"
            });
        }

        // Секретарь (если внешний)
        if (gak.Sekretar != null && gak.Sekretar.IsVneshniy)
        {
            result.Add(new OplataRowDto
            {
                PersonId = gak.Sekretar.Id,
                PersonName = gak.Sekretar.Name,
                RolVGek = "Секретарь"
            });
        }

        // Члены комиссии (только внешние)
        if (gak.Persons != null)
        {
            foreach (var person in gak.Persons.Where(p => p.IsVneshniy))
            {
                result.Add(new OplataRowDto
                {
                    PersonId = person.Id,
                    PersonName = person.Name,
                    RolVGek = "Участник"
                });
            }
        }

        return result.OrderBy(r => r.RolVGek).ThenBy(r => r.PersonName).ToList();
    }
}
