using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Komissiya;

public class SaveGakKomissiyaHandler
{
    private readonly AppDbContext _context;
    public SaveGakKomissiyaHandler(AppDbContext context) => _context = context;

    public async Task ExecuteAsync(SaveGakKomissiyaRequest request, CancellationToken ct = default)
    {
        var gak = await _context.Gak
            .Include(g => g.Persons)
            .FirstOrDefaultAsync(g => g.Id == request.GakId, ct);

        if (gak == null)
            throw new InvalidOperationException("ГАК не найден");

        // Устанавливаем председателя
        gak.PredsedatelId = request.PredsedatelId;

        // Устанавливаем секретаря
        gak.SekretarId = request.SekretarId;

        // Устанавливаем членов комиссии
        var chleny = await _context.Person
            .Where(p => request.ChlenyIds.Contains(p.Id))
            .ToListAsync(ct);

        gak.Persons = chleny;

        await _context.SaveChangesAsync(ct);
    }
}
