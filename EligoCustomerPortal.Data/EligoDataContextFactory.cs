using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EligoCustomerPortal.Data
{
    /// <summary>
    /// Used to generate an instance of <see cref="EligoDataContext"/> for migrations.
    /// 
    /// </summary>
    public class EligoDataContextFactory : IDesignTimeDbContextFactory<EligoDataContext>
    {
        public EligoDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EligoDataContext>();
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=EligoCustomerPortal;Trusted_Connection=True;");

            return new EligoDataContext(optionsBuilder.Options);
        }
    }
}
