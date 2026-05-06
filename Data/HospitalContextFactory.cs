using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PsiquiatriaAPI.Data
{
    public class HospitalContextFactory : IDesignTimeDbContextFactory<HospitalContext>
    {
        public HospitalContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HospitalContext>();

            optionsBuilder.UseNpgsql(
                "Host=trolley.proxy.rlwy.net;Port=43144;Database=railway;Username=postgres;Password=ORGtHkgmFQGbrxNuxyrHPpPfyMIztTqf");

            return new HospitalContext(optionsBuilder.Options);
        }
    }
}