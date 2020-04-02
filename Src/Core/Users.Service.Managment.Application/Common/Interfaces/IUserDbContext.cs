
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.Common.Interfaces
{
    public interface IUserDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<MarkupPlan> MarkupPlans { get; set; }

        DbSet<UserMarkupPlan> UserMarkupPlans { get; set; }

        DbSet<PointsRedeemPlan> PointsRedeemPlans { get; set; }

        DbSet<UserPointsRedeemPlan> UserPointsRedeemPlans { get; set; }

        DbSet<DefaultPointsRedeemPlan> DefaultPointsRedeemPlans { get; set; }

        DbSet<DefaultMarkupPlan> DefaultMarkupPlans { get; set; }

        DbSet<UserCreditCard> UserCreditCards { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
