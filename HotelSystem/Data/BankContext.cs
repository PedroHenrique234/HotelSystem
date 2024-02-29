using HotelSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSystem.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }
        public DbSet<ClientModel> Clients { get; set; }
    }
}
