using CarRental_Director.Model;
using System.Data.Entity;

namespace CarRental_Director
{
    public class DataContext : DbContext
    {
        #region DbSets

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

        #endregion

        #region Constructor

        public DataContext() : base("DefaultConnection")
        {
        }

        #endregion
    }
}
