
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Service.Managment.Domain;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Persistence.Configurations
{
    public class UserPointsRedeemPlanConfiguration : IEntityTypeConfiguration<UserPointsRedeemPlan>
    {
        public void Configure(EntityTypeBuilder<UserPointsRedeemPlan> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserPointsRedeemPlans)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Points_Redeem_Plans");

            builder.HasOne(d => d.PointsRedeemPlan)
                .WithMany(p => p.UserPointsRedeemPlans)
                .HasForeignKey(d => d.PointsRedeemPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Points_Redeem_Plans");


        }
    }
}
