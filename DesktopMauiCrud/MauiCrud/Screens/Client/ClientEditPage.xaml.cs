using DesktopMauiCrud.MauiCrud.DTO;
using DesktopMauiCrud.MauiCrud.ViewModels;

namespace DesktopMauiCrud.MauiCrud.Screens.Client;

[QueryProperty(nameof(Client), "Client")]
public partial class ClientEditPage : ContentPage
{
    private ClientEditViewModel vm;
    public ClientEditPage(ClientEditViewModel viewm)
	{
		InitializeComponent();
        BindingContext = viewm;
        vm = viewm;
    }

    private ClientDTO? _client;
    public ClientDTO Client
    {
        get => _client;
        set
        {
            _client = value;
            vm.LoadClient(this, _client);
        }
    }
    private void DateSelectedEvent(object sender, DateChangedEventArgs e)
    {

    }
}