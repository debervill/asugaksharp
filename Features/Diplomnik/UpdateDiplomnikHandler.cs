using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Diplomnik;

public class UpdateDiplomnikHandler
{
    private readonly AppDbContext _context;
    public UpdateDiplomnikHandler(AppDbContext context) => _context = context;

    public async Task<bool> ExecuteAsync(UpdateDiplomnikRequest request, CancellationToken ct = default)
    {
        var entity = await _context.Diplomnik.FirstOrDefaultAsync(d => d.Id == request.Id, ct);
        if (entity == null)
            return false;

        entity.FioImen = request.FioImen;
        entity.FioRodit = request.FioRodit;
        entity.Sex = request.Sex;
        entity.Pages = request.Pages;
        entity.Tema = request.Tema;
        entity.OrigVkr = request.OrigVkr;
        entity.Srball = request.Srball;
        entity.Otsenka = request.Otsenka;
        entity.VidVkr = request.VidVkr;
        entity.PersonId = request.PersonId;
        entity.ProfilPodgotovkiId = request.ProfilPodgotovkiId;

        var existingK = await _context.DiplomnikKonsultant
            .Where(dk => dk.DiplomnikId == request.Id)
            .ToListAsync(ct);
        _context.DiplomnikKonsultant.RemoveRange(existingK);

        for (int i = 0; i < request.KonsultantIds.Count; i++)
        {
            _context.DiplomnikKonsultant.Add(new Core.Entities.DiplomnikKonsultant
            {
                Id = Guid.NewGuid(),
                DiplomnikId = entity.Id,
                PersonId = request.KonsultantIds[i],
                SortOrder = i + 1
            });
        }

        var existingR = await _context.DiplomnikRetsenzent
            .Where(dr => dr.DiplomnikId == request.Id)
            .ToListAsync(ct);
        _context.DiplomnikRetsenzent.RemoveRange(existingR);

        for (int i = 0; i < request.RetsenzentIds.Count; i++)
        {
            _context.DiplomnikRetsenzent.Add(new Core.Entities.DiplomnikRetsenzent
            {
                Id = Guid.NewGuid(),
                DiplomnikId = entity.Id,
                PersonId = request.RetsenzentIds[i],
                SortOrder = i + 1
            });
        }

        await _context.SaveChangesAsync(ct);
        return true;
    }
}
