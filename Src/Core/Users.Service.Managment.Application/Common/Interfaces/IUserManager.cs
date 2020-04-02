using System.Threading.Tasks;

namespace Users.Service.Managment.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<string> CreateUserAsync(string userName, string password);
    }
}
