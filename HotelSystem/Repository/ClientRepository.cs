using HotelSystem.Data;
using HotelSystem.Models;

namespace HotelSystem.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BankContext _bankContext;
        public ClientRepository(BankContext bankContext)
        {
            this._bankContext = bankContext;
        }
        public ClientModel AddClient(ClientModel client)
        {
            DateTime checkIn = DateTime.Now;
            checkIn.ToString("dd/mm/yyyy");

            client.CheckIn = checkIn;
            _bankContext.Clients.Add(client);
            _bankContext.SaveChanges();
            return client;
        }

        public List<ClientModel> FindAll()
        {
            return _bankContext.Clients.ToList();
        }
        public ClientModel FindById(int id)
        {
            return _bankContext.Clients.FirstOrDefault(o => o.Id == id);
        }

        public ClientModel UpdateClient(ClientModel client)
        {
            ClientModel clientDb = FindById(client.Id);
            if (clientDb == null) throw new Exception("Impossível atualizar o cliente");

            clientDb.Name = client.Name;
            clientDb.Phone = client.Phone;
            clientDb.Room = client.Room;
            clientDb.Email = client.Email;
            clientDb.CheckOut = client.CheckOut;
            clientDb.CheckIn = client.CheckIn;
            clientDb.CheckOut = client.CheckOut;

            _bankContext.Clients.Update(clientDb);
            _bankContext.SaveChanges();
            return clientDb;
        }
    }
}
