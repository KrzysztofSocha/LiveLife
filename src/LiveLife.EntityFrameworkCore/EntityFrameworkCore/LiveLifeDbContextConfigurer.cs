using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LiveLife.EntityFrameworkCore
{
    public static class LiveLifeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LiveLifeDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LiveLifeDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
