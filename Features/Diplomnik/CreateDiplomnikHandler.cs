using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Diplomnik;

public class CreateDiplomnikHandler
{
    private readonly AppDbContext _context;
    public CreateDiplomnikHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateDiplomnikRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.Diplomnik
        {
            Id = Guid.NewGuid(),
            FioImen = request.FioImen,
            FioRodit = request.FioRodit,
            Sex = request.Sex,
            Pages = request.Pages,
            Tema = request.Tema,
            OrigVkr = request.OrigVkr,
            Srball = request.Srball,
            PersonId = request.PersonId,
            ProfilPodgotovkiId = request.ProfilPodgotovkiId
        };

        _context.Diplomnik.Add(entity);

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

        await _context.SaveChangesAsync(ct);
        return entity.Id;
    }
}
