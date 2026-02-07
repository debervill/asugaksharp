namespace asugaksharp.Features.Kafedra;

public record KafedraDto(Guid Id, string Name, string ShortName, string? Description);

public record CreateKafedraRequest(string Name, string ShortName, string? Description);

public record UpdateKafedraRequest(Guid Id, string Name, string ShortName, string? Description);