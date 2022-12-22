using Microsoft.EntityFrameworkCore;

namespace BeePortal.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Person> BeePeople => Set<Person>();


    }

}

