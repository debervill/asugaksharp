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
            StudentId = request.StudentId,
            ZasedanieId = request.ZasedanieId
        };

        _context.Diplomnik.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
