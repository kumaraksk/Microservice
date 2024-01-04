using CustomerService.Interceptor;
using CustomerService.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerService
{
    public class ApplicationDbContext:DbContext
    {
       
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .AddInterceptors(new DeleteInterceptor());
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasQueryFilter(x => x.IsDeleted == false);
        }
        public DbSet<Customer> customers { get;set; }
    }
}
