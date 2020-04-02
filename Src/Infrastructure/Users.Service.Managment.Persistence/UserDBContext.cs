using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Application.Common.Interfaces;
using Users.Service.Managment.Common;
using Users.Service.Managment.Domain.Common.Interfaces;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Persistence
{
    public class UserDBContext : DbContext, IUserDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }

        public UserDBContext(DbContextOptions<UserDBContext> options, ICurrentUserService currentUserService, IDateTime dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MarkupPlan> MarkupPlans { get; set; }
        public DbSet<UserMarkupPlan> UserMarkupPlans { get; set; }
        public DbSet<PointsRedeemPlan> PointsRedeemPlans { get; set; }
        public DbSet<UserPointsRedeemPlan> UserPointsRedeemPlans { get; set; }
        public DbSet<DefaultPointsRedeemPlan> DefaultPointsRedeemPlans { get; set; }
        public DbSet<DefaultMarkupPlan> DefaultMarkupPlans { get; set; }
        public DbSet<UserCreditCard> UserCreditCards { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _currentUserService.GetUserId();
                    entry.Entity.CreatedOn = _dateTime.Now;

                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedBy = _currentUserService.GetUserId();
                    entry.Entity.LastModifiedOn = _dateTime.Now;
                }
            }
          
           return base.SaveChangesAsync(cancellationToken);
         

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDBContext).Assembly);
        }
    }
}
