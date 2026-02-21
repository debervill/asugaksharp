using System.Collections.ObjectModel;
using asugaksharp.Features.Gak;

namespace asugaksharp.Features.Komissiya;

/// <summary>
/// ViewModel для управления составом комиссии ГАК
/// </summary>
public class KomissiyaViewModel
{
    // Доступные сотрудники (разделены по ролям)
    public ObservableCollection<KomissiyaPersonDto> AvailablePredsedateli { get; } = new();
    public ObservableCollection<KomissiyaPersonDto> AvailableSecretari { get; } = new();
    public ObservableCollection<KomissiyaPersonDto> AvailableSotrudniki { get; } = new();

    // Назначенные в комиссию
    public KomissiyaPersonDto? Predsedatel { get; private set; }
    public KomissiyaPersonDto? Sekretar { get; private set; }
    public ObservableCollection<KomissiyaPersonDto> Chleny { get; } = new();

    public bool HasChanges { get; private set; }

    public event Action? StateChanged;

    public void LoadKomissiya(List<KomissiyaPersonDto> allPersons, GakKomissiyaDto komissiya)
    {
        // Собираем ID уже назначенных в комиссию
        var assignedIds = new HashSet<Guid>();
        if (komissiya.Predsedatel != null) assignedIds.Add(komissiya.Predsedatel.Id);
        if (komissiya.Sekretar != null) assignedIds.Add(komissiya.Sekretar.Id);
        foreach (var chlen in komissiya.Chleny) assignedIds.Add(chlen.Id);

        // Заполняем текущий состав комиссии
        Predsedatel = komissiya.Predsedatel;
        Sekretar = komissiya.Sekretar;

        Chleny.Clear();
        foreach (var chlen in komissiya.Chleny)
            Chleny.Add(chlen);

        // Распределяем доступных сотрудников по категориям
        AvailablePredsedateli.Clear();
        AvailableSecretari.Clear();
        AvailableSotrudniki.Clear();

        foreach (var person in allPersons)
        {
            if (assignedIds.Contains(person.Id))
                continue;

            if (person.IsPredsed)
                AvailablePredsedateli.Add(person);

            if (person.IsSecretar)
                AvailableSecretari.Add(person);

            AvailableSotrudniki.Add(person);
        }

        HasChanges = false;
        StateChanged?.Invoke();
    }

    public void Clear()
    {
        Predsedatel = null;
        Sekretar = null;
        Chleny.Clear();
        AvailablePredsedateli.Clear();
        AvailableSecretari.Clear();
        AvailableSotrudniki.Clear();
        HasChanges = false;
        StateChanged?.Invoke();
    }

    public string? AssignPredsedatel(KomissiyaPersonDto person)
    {
        if (Predsedatel != null)
            return "Председатель уже назначен. Сначала уберите текущего.";

        Predsedatel = person;
        RemoveFromAllLists(person);
        MarkChanged();
        return null;
    }

    public string? UnassignPredsedatel()
    {
        if (Predsedatel == null)
            return "Председатель не назначен";

        var person = Predsedatel;
        Predsedatel = null;
        ReturnToLists(person);
        MarkChanged();
        return null;
    }

    public string? AssignSekretar(KomissiyaPersonDto person)
    {
        if (Sekretar != null)
            return "Секретарь уже назначен. Сначала уберите текущего.";

        Sekretar = person;
        RemoveFromAllLists(person);
        MarkChanged();
        return null;
    }

    public string? UnassignSekretar()
    {
        if (Sekretar == null)
            return "Секретарь не назначен";

        var person = Sekretar;
        Sekretar = null;
        ReturnToLists(person);
        MarkChanged();
        return null;
    }

    public void AddChlen(KomissiyaPersonDto person)
    {
        Chleny.Add(person);
        RemoveFromAllLists(person);
        MarkChanged();
    }

    public string? RemoveChlen(KomissiyaPersonDto person)
    {
        if (!Chleny.Contains(person))
            return "Выберите члена комиссии для удаления";

        Chleny.Remove(person);
        ReturnToLists(person);
        MarkChanged();
        return null;
    }

    public List<string> Validate()
    {
        var errors = new List<string>();

        if (Predsedatel == null)
            errors.Add("Не назначен председатель");

        if (Sekretar == null)
            errors.Add("Не назначен секретарь");

        if (Chleny.Count < 3)
            errors.Add($"Недостаточно членов комиссии (назначено {Chleny.Count}, требуется минимум 3)");

        return errors;
    }

    public SaveGakKomissiyaRequest CreateSaveRequest(Guid gakId)
    {
        return new SaveGakKomissiyaRequest(
            gakId,
            Predsedatel!.Id,
            Sekretar!.Id,
            Chleny.Select(c => c.Id).ToList());
    }

    public void MarkSaved()
    {
        HasChanges = false;
        StateChanged?.Invoke();
    }

    private void RemoveFromAllLists(KomissiyaPersonDto person)
    {
        RemoveById(AvailablePredsedateli, person.Id);
        RemoveById(AvailableSecretari, person.Id);
        RemoveById(AvailableSotrudniki, person.Id);
    }

    private void ReturnToLists(KomissiyaPersonDto person)
    {
        if (person.IsPredsed) AvailablePredsedateli.Add(person);
        if (person.IsSecretar) AvailableSecretari.Add(person);
        AvailableSotrudniki.Add(person);
    }

    private static void RemoveById(ObservableCollection<KomissiyaPersonDto> collection, Guid id)
    {
        var item = collection.FirstOrDefault(p => p.Id == id);
        if (item != null) collection.Remove(item);
    }

    private void MarkChanged()
    {
        HasChanges = true;
        StateChanged?.Invoke();
    }
}
