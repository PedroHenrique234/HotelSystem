namespace HotelSystem.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}


