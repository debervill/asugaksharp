namespace asugaksharp;

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using asugaksharp.Core.Common;
using asugaksharp.Features.Kafedra.GetKafedraList;

public partial class MainViewModel : ObservableObject
{
    private readonly RequestDispatcher _dispatcher;

    [ObservableProperty]
    private string _title = "АСУГАК";

    [ObservableProperty]
    private ObservableCollection<KafedraDto> _kafedras = new();

    [ObservableProperty]
    private bool _isLoading;

    public MainViewModel(RequestDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [RelayCommand]
    private async Task LoadKafedrasAsync()
    {
        IsLoading = true;

        var result = await _dispatcher.SendAsync(new GetKafedraListQuery());

        if (result.IsSuccess)
        {
            Kafedras.Clear();
            foreach (var kafedra in result.Value!)
            {
                Kafedras.Add(kafedra);
            }
        }
        else
        {
            System.Windows.MessageBox.Show(result.Error, "Ошибка",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Error);
        }

        IsLoading = false;
    }
}