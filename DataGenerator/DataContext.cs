using DataGenerator.Model;
using Microsoft.EntityFrameworkCore;

namespace DataGenerator
{
    class DataContext : DbContext
    {
        #region DbSets

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

        #endregion

        #region Constructor

        public DataContext() : base()
        {
        }

        #endregion

        #region OverridedMethods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-DPE2P6U\\SQLEXPRESS;Database=CARRENTAL_DIRECTOR;Trusted_Connection=True;");
        }

        #endregion
    }
}
