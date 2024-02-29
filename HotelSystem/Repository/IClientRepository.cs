using HotelSystem.Models;

namespace HotelSystem.Repository
{
    public interface IClientRepository
    {
        public ClientModel AddClient(ClientModel client);
    }
}
