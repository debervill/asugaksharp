using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.ProfilPodgotovki;

public class CreateProfilPodgotovkiHandler
{
    private readonly AppDbContext _context;
    public CreateProfilPodgotovkiHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateProfilPodgotovkiRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.ProfilPodgotovki
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ShifrPodgot = request.ShifrPodgot,
            NapravleniePodgotovkiID = request.NapravleniePodgotovkiId
        };

        _context.ProfilPodgotovki.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
