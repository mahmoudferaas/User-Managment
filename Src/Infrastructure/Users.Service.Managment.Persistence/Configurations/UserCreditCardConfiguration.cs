
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Service.Managment.Domain;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Persistence.Configurations
{
    public class UserCreditCardConfiguration : IEntityTypeConfiguration<UserCreditCard>
    {
        public void Configure(EntityTypeBuilder<UserCreditCard> builder)
        {

            builder.HasOne(d => d.User)
                .WithMany(p => p.UserCreditCards)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserCreditCard_User_UserId");


        }
    }
}
