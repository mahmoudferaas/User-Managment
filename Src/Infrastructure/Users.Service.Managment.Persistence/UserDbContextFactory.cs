using Microsoft.EntityFrameworkCore;

namespace Users.Service.Managment.Persistence
{
    public class UserDbContextFactory : DesignTimeDbContextFactoryBase<UserDBContext>
    {
        protected override UserDBContext CreateNewInstance(DbContextOptions<UserDBContext> options)
        {
            return new UserDBContext(options);
        }
    }
}
