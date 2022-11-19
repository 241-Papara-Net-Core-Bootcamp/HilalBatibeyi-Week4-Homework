using Microsoft.EntityFrameworkCore;
using Owner.API.Model;
using Owner.DataAccess.Configurations;

namespace Owner.DataAccess.Context
{
    public class OwnerDbContext : DbContext
    {
        public OwnerDbContext(DbContextOptions<OwnerDbContext> options) : base(options)
        {

        }

        // The class given in the DbSet becomes a table in the database.
        public DbSet<OwnerModel> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server =(localdb)\MSSQLLocalDB; Database = OwnerDb; Trusted_Connection=true");
        //}
    }
}
