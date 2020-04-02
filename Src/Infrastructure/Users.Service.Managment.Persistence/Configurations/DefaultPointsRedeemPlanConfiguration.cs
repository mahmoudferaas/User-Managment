
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Service.Managment.Domain;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Persistence.Configurations
{
    public class DefaultPointsRedeemPlanConfiguration : IEntityTypeConfiguration<DefaultPointsRedeemPlan>
    {
        public void Configure(EntityTypeBuilder<DefaultPointsRedeemPlan> builder)
        {

            builder.HasOne(d => d.PointsRedeemPlan)
                .WithMany(p => p.DefaultPointsRedeemPlans)
                .HasForeignKey(d => d.PointsRedeemPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DefaultPointsRedeemPlan_PointsRedeemPlan_PointsRedeemPlanId");


        }
    }
}
