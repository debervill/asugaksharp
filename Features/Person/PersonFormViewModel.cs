namespace asugaksharp.Features.Person;

/// <summary>
/// ViewModel для формы редактирования сотрудника
/// </summary>
public class PersonFormViewModel
{
    public Guid? EditingId { get; private set; }
    public string Name { get; set; } = "";
    public string Stepen { get; set; } = "";
    public string Zvanie { get; set; } = "";
    public string Dolgnost { get; set; } = "";
    public bool IsPredsed { get; set; }
    public bool IsZavKaf { get; set; }
    public bool IsSecretar { get; set; }
    public bool IsRecenzent { get; set; }
    public bool IsVneshniy { get; set; }
    public Guid? KafedraId { get; set; }

    public bool IsEditing => EditingId.HasValue;

    public void LoadForEdit(PersonDto person)
    {
        EditingId = person.Id;
        Name = person.Name;
        Stepen = person.Stepen;
        Zvanie = person.Zvanie;
        Dolgnost = person.Dolgnost;
        IsPredsed = person.IsPredsed;
        IsZavKaf = person.IsZavKaf;
        IsSecretar = person.IsSecretar;
        IsRecenzent = person.IsRecenzent;
        IsVneshniy = person.IsVneshniy;
        KafedraId = person.KafedraId;
    }

    public void Clear()
    {
        EditingId = null;
        Name = "";
        Stepen = "";
        Zvanie = "";
        Dolgnost = "";
        IsPredsed = false;
        IsZavKaf = false;
        IsSecretar = false;
        IsRecenzent = false;
        IsVneshniy = false;
        KafedraId = null;
    }

    public string? Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            return "Введите ФИО";

        if (!KafedraId.HasValue)
            return "Выберите кафедру";

        return null;
    }

    public CreatePersonRequest ToCreateRequest()
    {
        return new CreatePersonRequest(
            Name,
            Stepen,
            Zvanie,
            Dolgnost,
            IsPredsed,
            IsZavKaf,
            IsSecretar,
            IsRecenzent,
            IsVneshniy,
            KafedraId!.Value);
    }

    public UpdatePersonRequest ToUpdateRequest()
    {
        return new UpdatePersonRequest(
            EditingId!.Value,
            Name,
            Stepen,
            Zvanie,
            Dolgnost,
            IsPredsed,
            IsZavKaf,
            IsSecretar,
            IsRecenzent,
            IsVneshniy,
            KafedraId!.Value);
    }
}
