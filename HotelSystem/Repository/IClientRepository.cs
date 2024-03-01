using HotelSystem.Models;

namespace HotelSystem.Repository
{
    public interface IClientRepository
    {
        public ClientModel AddClient(ClientModel client);
        public List<ClientModel> FindAll();
        public ClientModel FindById(int id);
        public ClientModel UpdateClient(ClientModel client);
        public bool DeletClient(int id);
        public ClientModel Checkout(ClientModel client);
    }
}
