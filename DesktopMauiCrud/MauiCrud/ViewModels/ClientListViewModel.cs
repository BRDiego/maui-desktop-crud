using DesktopMauiCrud.MauiCrud.Data.Interface.UseCase;
using DesktopMauiCrud.MauiCrud.DTO;
using DesktopMauiCrud.MauiCrud.Services;
using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;

namespace DesktopMauiCrud.MauiCrud.ViewModels
{
    public class ClientListViewModel
    {
        private readonly ClientService _service;
        public ObservableCollection<ClientDTO> clients;

        public ClientListViewModel(ClientService ser)
        {
            _service = ser;
            clients = new ObservableCollection<ClientDTO>();
            RefreshList();
        }

        public void RefreshList()
        {
            clients = new ObservableCollection<ClientDTO>(_service.List());
        }

        public void SaveClient(ClientDTO cli)
        {
            _service.Save(cli);
        }
    }
}
