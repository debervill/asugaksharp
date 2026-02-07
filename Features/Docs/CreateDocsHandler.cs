using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Docs;

public class CreateDocsHandler
{
    private readonly AppDbContext _context;
    public CreateDocsHandler(AppDbContext context) => _context = context;

    public async Task<Guid> ExecuteAsync(CreateDocsRequest request, CancellationToken ct = default)
    {
        var entity = new Core.Entities.Docs
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            IsUploaded = request.IsUploaded,
            Data = request.Data,
            PersonId = request.PersonId
        };

        _context.Docs.Add(entity);
        await _context.SaveChangesAsync(ct);

        return entity.Id;
    }
}
