using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LiveLife.Authorization.Roles;
using LiveLife.Authorization.Users;
using LiveLife.MultiTenancy;

namespace LiveLife.EntityFrameworkCore
{
    public class LiveLifeDbContext : AbpZeroDbContext<Tenant, Role, User, LiveLifeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LiveLifeDbContext(DbContextOptions<LiveLifeDbContext> options)
            : base(options)
        {
        }
    }
}
