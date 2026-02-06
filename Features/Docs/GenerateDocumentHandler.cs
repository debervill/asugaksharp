using Microsoft.EntityFrameworkCore;
using asugaksharp.Infrastructure.Persistence;

namespace asugaksharp.Features.Docs;

public class GenerateDocumentHandler
{
    private readonly AppDbContext _context;
    private readonly DocumentGenerator _documentGenerator;

    public GenerateDocumentHandler(AppDbContext context, DocumentGenerator documentGenerator)
    {
        _context = context;
        _documentGenerator = documentGenerator;
    }

    /// <summary>
    /// Генерирует документы для конкретной записи оплаты
    /// </summary>
    public async Task<GenerateDocumentResult> ExecuteAsync(
        Guid oplataId,
        DocumentType documentType,
        string outputPath,
        CancellationToken ct = default)
    {
        var oplata = await _context.Oplata
            .Include(o => o.Person)
            .Include(o => o.Gak)
            .FirstOrDefaultAsync(o => o.Id == oplataId, ct);

        if (oplata == null)
            return new GenerateDocumentResult(false, null, "Запись оплаты не найдена");

        if (oplata.Person == null)
            return new GenerateDocumentResult(false, null, "Сотрудник не найден");

        if (oplata.Gak == null)
            return new GenerateDocumentResult(false, null, "ГАК не найден");

        try
        {
            var filePath = documentType switch
            {
                DocumentType.Dogovor => _documentGenerator.GenerateDogovor(oplata.Person, oplata, oplata.Gak, outputPath),
                DocumentType.Akt => _documentGenerator.GenerateAkt(oplata.Person, oplata, oplata.Gak, outputPath),
                DocumentType.Zayavlenie => _documentGenerator.GenerateZayavlenie(oplata.Person, oplata, outputPath),
                _ => throw new ArgumentException("Неизвестный тип документа")
            };

            // Отмечаем что договор сгенерирован
            if (documentType == DocumentType.Dogovor)
            {
                oplata.IsDogovorGenerated = true;
                await _context.SaveChangesAsync(ct);
            }

            return new GenerateDocumentResult(true, filePath, null);
        }
        catch (Exception ex)
        {
            return new GenerateDocumentResult(false, null, ex.Message);
        }
    }

    /// <summary>
    /// Генерирует все документы для записи оплаты
    /// </summary>
    public async Task<GenerateAllDocumentsResult> ExecuteAllAsync(
        Guid oplataId,
        string outputPath,
        CancellationToken ct = default)
    {
        var oplata = await _context.Oplata
            .Include(o => o.Person)
            .Include(o => o.Gak)
            .FirstOrDefaultAsync(o => o.Id == oplataId, ct);

        if (oplata == null)
            return new GenerateAllDocumentsResult(false, null, "Запись оплаты не найдена");

        if (oplata.Person == null)
            return new GenerateAllDocumentsResult(false, null, "Сотрудник не найден");

        if (oplata.Gak == null)
            return new GenerateAllDocumentsResult(false, null, "ГАК не найден");

        try
        {
            var result = _documentGenerator.GenerateAllDocuments(oplata.Person, oplata, oplata.Gak, outputPath);

            if (result.DogovorPath != null)
            {
                oplata.IsDogovorGenerated = true;
                await _context.SaveChangesAsync(ct);
            }

            return new GenerateAllDocumentsResult(true, result, null);
        }
        catch (Exception ex)
        {
            return new GenerateAllDocumentsResult(false, null, ex.Message);
        }
    }

    /// <summary>
    /// Генерирует документы для всех записей оплаты по ГАК
    /// </summary>
    public async Task<GenerateBatchResult> ExecuteForGakAsync(
        Guid gakId,
        DocumentType documentType,
        string outputPath,
        CancellationToken ct = default)
    {
        var oplatas = await _context.Oplata
            .Include(o => o.Person)
            .Include(o => o.Gak)
            .Where(o => o.GakId == gakId)
            .ToListAsync(ct);

        if (!oplatas.Any())
            return new GenerateBatchResult(0, 0, new List<string> { "Записи оплаты для данного ГАК не найдены" });

        var successCount = 0;
        var errors = new List<string>();

        foreach (var oplata in oplatas)
        {
            if (oplata.Person == null)
            {
                errors.Add($"Сотрудник не найден для оплаты {oplata.Id}");
                continue;
            }

            if (oplata.Gak == null)
            {
                errors.Add($"ГАК не найден для оплаты {oplata.Id}");
                continue;
            }

            try
            {
                switch (documentType)
                {
                    case DocumentType.Dogovor:
                        _documentGenerator.GenerateDogovor(oplata.Person, oplata, oplata.Gak, outputPath);
                        oplata.IsDogovorGenerated = true;
                        break;
                    case DocumentType.Akt:
                        _documentGenerator.GenerateAkt(oplata.Person, oplata, oplata.Gak, outputPath);
                        break;
                    case DocumentType.Zayavlenie:
                        _documentGenerator.GenerateZayavlenie(oplata.Person, oplata, outputPath);
                        break;
                }
                successCount++;
            }
            catch (Exception ex)
            {
                errors.Add($"{oplata.Person.Name}: {ex.Message}");
            }
        }

        await _context.SaveChangesAsync(ct);

        return new GenerateBatchResult(successCount, oplatas.Count, errors);
    }
}

public enum DocumentType
{
    Dogovor,
    Akt,
    Zayavlenie
}

public record GenerateDocumentResult(bool Success, string? FilePath, string? Error);

public record GenerateAllDocumentsResult(bool Success, GeneratedDocumentsResult? Documents, string? Error);

public record GenerateBatchResult(int SuccessCount, int TotalCount, List<string> Errors)
{
    public bool HasErrors => Errors.Count > 0;
    public bool IsFullSuccess => SuccessCount == TotalCount && !HasErrors;
}
