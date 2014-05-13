using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataAccess.Models;

namespace DataAccess.DataAccessLayer
{
    public class LunchContext : DbContext
    {
        public LunchContext()
            : base("LunchContext")
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Lunch> Lunches { get; set; }
        public DbSet<PersonToLunch> PersonToLunches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
