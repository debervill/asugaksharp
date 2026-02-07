using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.NapravleniePodgotovki;

public class CreateNapravleniePodgotovkiHandler
{
    private readonly AppDbContext _context;
    public CreateNapravleniePodgotovkiHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateNapravleniePodgotovkiRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.NapravleniePodgotovki
        {
            Id = Guid.NewGuid(),
            Nazvanie = request.Nazvanie,
            ShifrNapr = request.ShifrNapr
        };

        _context.NapravleniePodgotovki.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
