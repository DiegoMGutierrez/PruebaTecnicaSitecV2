using PruebaTecnicaSitecV2.Models;

namespace PruebaTecnicaSitecV2.Interfaces
{
    public interface IClientService
    {
        List<Client> GetClients();
        bool VerifyClient(int id);
    }
}
