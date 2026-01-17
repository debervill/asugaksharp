using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Oplata;

public class CreateOplataHandler
{
    private readonly AppDbContext _context;
    public CreateOplataHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateOplataRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.Oplata
        {
            Id = Guid.NewGuid(),
            Stavka = request.Stavka,
            Ndfl = request.Ndfl,
            Enp = request.Enp,
            MoneySource = request.MoneySource,
            DogovorNumber = request.DogovorNumber,
            PersonId = request.PersonId
        };

        _context.Oplata.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
