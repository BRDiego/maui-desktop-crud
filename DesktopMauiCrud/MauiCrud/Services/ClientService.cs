using DesktopMauiCrud.MauiCrud.Data.Interface.UseCase;
using DesktopMauiCrud.MauiCrud.DTO;
using DesktopMauiCrud.MauiCrud.DTO.Mappers;

namespace DesktopMauiCrud.MauiCrud.Services
{
    public class ClientService
    {

        private readonly IClientDAO _dao;

        public ClientService(IClientDAO dao)
        {
            _dao = dao;
        }

        public IEnumerable<ClientDTO> List()
        {
            return _dao.List().AsEnumerable().Select(x => x.ToDto());
        }

        public void Save(ClientDTO cli)
        {
            _dao.Save(cli.ToEntity());
        }
    }
}
