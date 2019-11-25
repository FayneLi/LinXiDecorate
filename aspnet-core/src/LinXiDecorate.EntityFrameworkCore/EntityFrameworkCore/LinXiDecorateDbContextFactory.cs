using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using LinXiDecorate.Configuration;
using LinXiDecorate.Web;

namespace LinXiDecorate.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LinXiDecorateDbContextFactory : IDesignTimeDbContextFactory<LinXiDecorateDbContext>
    {
        public LinXiDecorateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LinXiDecorateDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LinXiDecorateDbContextConfigurer.Configure(builder, configuration.GetConnectionString(LinXiDecorateConsts.ConnectionStringName));

            return new LinXiDecorateDbContext(builder.Options);
        }
    }
}
