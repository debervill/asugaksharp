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

        // Председатель (если внешний) — коэффициент 1
        if (gak.Predsedatel != null && gak.Predsedatel.IsVneshniy)
        {
            result.Add(new OplataRowDto
            {
                PersonId = gak.Predsedatel.Id,
                PersonName = gak.Predsedatel.Name,
                RolVGek = "Председатель",
                Koefficient = 1f
            });
        }

        // Секретарь (если внешний) — коэффициент 0.5
        if (gak.Sekretar != null && gak.Sekretar.IsVneshniy)
        {
            result.Add(new OplataRowDto
            {
                PersonId = gak.Sekretar.Id,
                PersonName = gak.Sekretar.Name,
                RolVGek = "Секретарь",
                Koefficient = 0.5f
            });
        }

        // Члены комиссии (только внешние)
        if (gak.Persons != null)
        {
            foreach (var person in gak.Persons.Where(p => p.IsVneshniy))
            {
                // Рецензент — коэффициент 4, иначе — 0.5
                var isRecenzent = person.IsRecenzent;
                result.Add(new OplataRowDto
                {
                    PersonId = person.Id,
                    PersonName = person.Name,
                    RolVGek = isRecenzent ? "Рецензент" : "Участник",
                    Koefficient = isRecenzent ? 4f : 0.5f
                });
            }
        }

        return result.OrderBy(r => r.RolVGek).ThenBy(r => r.PersonName).ToList();
    }
}
