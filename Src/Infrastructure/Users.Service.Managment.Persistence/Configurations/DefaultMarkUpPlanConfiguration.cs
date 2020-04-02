
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Service.Managment.Domain;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Persistence.Configurations
{
    public class DefaultMarkUpPlanConfiguration : IEntityTypeConfiguration<DefaultMarkupPlan>
    {
        public void Configure(EntityTypeBuilder<DefaultMarkupPlan> builder)
        {

            builder.HasOne(d => d.MarkupPlan)
                .WithMany(p => p.DefaultMarkupPlans)
                .HasForeignKey(d => d.MarkupPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DefaultMarkupPlan_MarkupPlan_MarkupPlanId");


        }
    }
}
