
using DesktopMauiCrud.MauiCrud.Core.Entities;
using DesktopMauiCrud.MauiCrud.Data.Interface;
using DesktopMauiCrud.MauiCrud.Data.Interface.UseCase;

namespace DesktopMauiCrud.MauiCrud.Data.DAOs
{
    public class ClientDAO : IClientDAO
    {
        private readonly IDataStorage<Client> _clientStorage;

        public ClientDAO(
            IDataStorage<Client> clientStorage)
        {
            _clientStorage = clientStorage;
        }

        public void Delete(Client client)
        {
            _clientStorage.Delete(client);
        }

        public Client Get(Guid id)
        {
            return _clientStorage.Get(x => x.Id == id);
        }

        public IEnumerable<Client> List()
        {
            return _clientStorage.List();
        }

        public void Save(Client client)
        {
            _clientStorage.Save(client);
        }
    }
}
