using PruebaTecnicaSitecV2.Data;
using PruebaTecnicaSitecV2.Interfaces;
using PruebaTecnicaSitecV2.Models;

namespace PruebaTecnicaSitecV2.Services
{
    public class ClientService:IClientService
    {
        private readonly AppDbContext _db;
        public ClientService(AppDbContext db)
        {
            _db = db;
        }
        public List<Client> GetClients()
        {
            return _db.Clients.ToList();
        }
        public bool VerifyClient(int id)
        {
            if (_db.Clients.Find(id) != null)
                return true;
            else
                return false;
        }
    }
}
