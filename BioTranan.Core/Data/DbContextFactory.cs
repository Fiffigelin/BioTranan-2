using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BioTranan.Core.Data
{
    public class BioTrananDbContextFactory : IDesignTimeDbContextFactory<BioTrananDbContext>
    {
        public BioTrananDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BioTrananDbContext>();
            optionsBuilder.UseSqlite("Data Source=BioTrananDb.db");

            return new BioTrananDbContext(optionsBuilder.Options);
        }
    }
}