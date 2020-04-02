
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Service.Managment.Domain;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Persistence.Configurations
{
    public class UserMarkUpPlanConfiguration : IEntityTypeConfiguration<UserMarkupPlan>
    {
        public void Configure(EntityTypeBuilder<UserMarkupPlan> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserMarkupPlans)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMarkupPlan_User_UserId");

            builder.HasOne(d => d.MarkupPlan)
                .WithMany(p => p.UserMarkupPlans)
                .HasForeignKey(d => d.MarkupPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMarkupPlan_MarkupPlan_MarkupPlanId");


        }
    }
}
