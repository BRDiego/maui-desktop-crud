using DesktopMauiCrud.MauiCrud.Core.Entities;

namespace DesktopMauiCrud.MauiCrud.Data.Interface.UseCase
{
    public interface IClientDAO
    {
        void Save(Client client);
        Client Get(Guid id);
        void Delete(Client client);
        IEnumerable<Client> List();
    }
}
