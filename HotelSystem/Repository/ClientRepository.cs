using HotelSystem.Data;
using HotelSystem.Models;

namespace HotelSystem.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BankContext _bankContext;
        public ClientRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public ClientModel AddClient(ClientModel client)
        {
            client.CheckIn = DateTime.Now;
            _bankContext.Clients.Add(client);
            _bankContext.SaveChanges();
            return client;
        }
    }
}
