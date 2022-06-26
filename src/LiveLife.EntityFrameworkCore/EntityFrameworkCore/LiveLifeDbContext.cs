using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LiveLife.Authorization.Roles;
using LiveLife.Authorization.Users;
using LiveLife.MultiTenancy;
using LiveLife.Models;

namespace LiveLife.EntityFrameworkCore
{
    public class LiveLifeDbContext : AbpZeroDbContext<Tenant, Role, User, LiveLifeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Event> Events { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }

        public LiveLifeDbContext(DbContextOptions<LiveLifeDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserFriend>().HasKey(x => new { x.SenderUserId, x.ReceiverUserId });
            modelBuilder.Entity<UserFriend>().HasOne(x => x.SenderUser)
                .WithMany(x => x.AddedUserFriends)
                .HasForeignKey(x=>x.SenderUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserFriend>().HasOne(x => x.ReceiverUser)
                .WithMany(x => x.AcceptedUserFriends)
                .HasForeignKey(x=>x.ReceiverUserId)
                .OnDelete(DeleteBehavior.NoAction);
                
           
            
           
               
        }
    }
}
