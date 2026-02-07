using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Person;

public class CreatePersonHandler
{
    private readonly AppDbContext _context;
    public CreatePersonHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreatePersonRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.Person
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Stepen = request.Stepen,
            Zvanie = request.Zvanie,
            Dolgnost = request.Dolgnost,
            IsPredsed = request.IsPredsed,
            IsZavKaf = request.IsZavKaf,
            IsSecretar = request.IsSecretar,
            IsRecenzent = request.IsRecenzent,
            IsVneshniy = request.IsVneshniy,
            KafedraID = request.KafedraId
        };

        _context.Person.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
