namespace asugaksharp.Features.Docs;

public record DocsDto(
    Guid Id,
    string Name,
    bool IsUploaded,
    string Data,
    Guid PersonId,
    string? PersonName);

public record CreateDocsRequest(
    string Name,
    bool IsUploaded,
    string Data,
    Guid PersonId);

public record UpdateDocsRequest(
    Guid Id,
    string Name,
    bool IsUploaded,
    string Data,
    Guid PersonId);
