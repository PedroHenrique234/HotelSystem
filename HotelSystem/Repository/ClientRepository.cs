using HotelSystem.Data;
using HotelSystem.Models;
using Microsoft.AspNetCore.Mvc;

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
            bool clientActive = true;
            DateTime checkIn = DateTime.Now;
            checkIn.ToString("dd/mm/yyyy");

            client.CheckIn = checkIn;
            client.ActiveClient = clientActive;
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

            _bankContext.Clients.Update(clientDb);
            _bankContext.SaveChanges();
            return clientDb;
        }
        public bool DeletClient(int id)
        {
            ClientModel clientDb = FindById(id);
            if (clientDb == null) throw new Exception("Impossivel deletar este cliente");

            _bankContext.Remove(clientDb);
            _bankContext.SaveChanges();
            return true;
        }

        public ClientModel Checkout(ClientModel client)
        {
            ClientModel clientDb = FindById(client.Id);

            clientDb.ActiveClient = false;
            _bankContext.Clients.Update(clientDb);
            _bankContext.SaveChanges();
            return clientDb;
        }
    }
}
