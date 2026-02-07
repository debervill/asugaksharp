namespace asugaksharp.Features.Komissiya;

public record KomissiyaPersonDto(
    Guid Id,
    string Name,
    string Stepen,
    string Zvanie,
    string Dolgnost,
    bool IsPredsed,
    bool IsSecretar);

public record GakKomissiyaDto(
    KomissiyaPersonDto? Predsedatel,
    KomissiyaPersonDto? Sekretar,
    List<KomissiyaPersonDto> Chleny);

public record SaveGakKomissiyaRequest(
    Guid GakId,
    Guid PredsedatelId,
    Guid SekretarId,
    List<Guid> ChlenyIds);
