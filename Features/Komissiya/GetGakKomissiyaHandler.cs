using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Komissiya;

public class GetGakKomissiyaHandler
{
    private readonly AppDbContext _context;
    public GetGakKomissiyaHandler(AppDbContext context) => _context = context;

    public async Task<GakKomissiyaDto> ExecuteAsync(Guid gakId, CancellationToken ct = default)
    {
        var gak = await _context.Gak
            .AsNoTracking()
            .Include(g => g.Predsedatel)
            .Include(g => g.Sekretar)
            .Include(g => g.Persons)
            .FirstOrDefaultAsync(g => g.Id == gakId, ct);

        if (gak == null)
            return new GakKomissiyaDto(null, null, new List<KomissiyaPersonDto>());

        KomissiyaPersonDto? predsedatel = null;
        if (gak.Predsedatel != null)
        {
            predsedatel = new KomissiyaPersonDto(
                gak.Predsedatel.Id,
                gak.Predsedatel.Name,
                gak.Predsedatel.Stepen,
                gak.Predsedatel.Zvanie,
                gak.Predsedatel.Dolgnost,
                gak.Predsedatel.IsPredsed,
                gak.Predsedatel.IsSecretar);
        }

        KomissiyaPersonDto? sekretar = null;
        if (gak.Sekretar != null)
        {
            sekretar = new KomissiyaPersonDto(
                gak.Sekretar.Id,
                gak.Sekretar.Name,
                gak.Sekretar.Stepen,
                gak.Sekretar.Zvanie,
                gak.Sekretar.Dolgnost,
                gak.Sekretar.IsPredsed,
                gak.Sekretar.IsSecretar);
        }

        var chleny = gak.Persons?
            .Select(p => new KomissiyaPersonDto(
                p.Id,
                p.Name,
                p.Stepen,
                p.Zvanie,
                p.Dolgnost,
                p.IsPredsed,
                p.IsSecretar))
            .OrderBy(p => p.Name)
            .ToList() ?? new List<KomissiyaPersonDto>();

        return new GakKomissiyaDto(predsedatel, sekretar, chleny);
    }
}
