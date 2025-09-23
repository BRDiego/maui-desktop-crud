using DesktopMauiCrud.MauiCrud.DTO;
using DesktopMauiCrud.MauiCrud.Screens;
using DesktopMauiCrud.MauiCrud.Screens.Client;
using DesktopMauiCrud.MauiCrud.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesktopMauiCrud.MauiCrud.ViewModels
{
    public class ClientListViewModel :INotifyPropertyChanged
    {
        private readonly ClientService _service;
        public ObservableCollection<ClientDTO> Clients { get; private set; }
        public Command AddClientCommand { get; }


        public ClientListViewModel(ClientService ser)
        {
            _service = ser;
            Clients = new ObservableCollection<ClientDTO>();
            RefreshList();

            AddClientCommand = new Command<Page>(OpenAddClient);
        }

        private async void OpenAddClient(Page page)
        {
            try
            {
                await Shell.Current.GoToAsync(nameof(ClientEditPage));
            }
            catch (Exception ex)
            {
                await AppUtils.ErrorAlert(page, ex);
            }
        }

        public void RefreshList()
        {
            Clients = new ObservableCollection<ClientDTO>(_service.List());
            OnPropertyChanged(nameof(Clients));
        }

        public void SaveClient(ClientDTO cli)
        {
            _service.Save(cli);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
