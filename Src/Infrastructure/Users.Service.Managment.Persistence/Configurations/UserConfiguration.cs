
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id).HasColumnName("UserId");

            builder.HasOne(d => d.ParentUser)
                .WithMany(p => p.SubUsers)
                .HasForeignKey(d => d.ParentUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_User_ParentUserId");
        }
    }
}
