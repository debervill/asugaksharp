using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Kafedra;

public class CreateKafedraHandler
{
    private readonly AppDbContext _context;
    public CreateKafedraHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateKafedraRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.Kafedra
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ShortName = request.ShortName,
            Description = request.Description
        };

        _context.Kafedra.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}