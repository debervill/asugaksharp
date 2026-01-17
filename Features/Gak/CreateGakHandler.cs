using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Gak;

public class CreateGakHandler
{
    private readonly AppDbContext _context;
    public CreateGakHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateGakRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.Gak
        {
            Id = Guid.NewGuid(),
            NomerPrikaza = request.NomerPrikaza,
            KolvoBudget = request.KolvoBudget,
            KolvoPlatka = request.KolvoPlatka,
            PeriodZasedaniaId = request.PeriodZasedaniaId,
            KafedraID = request.KafedraId
        };

        _context.Gak.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
