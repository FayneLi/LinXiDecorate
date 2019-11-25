using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LinXiDecorate.EntityFrameworkCore
{
    public static class LinXiDecorateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LinXiDecorateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LinXiDecorateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
