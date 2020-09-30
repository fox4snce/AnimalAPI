using AnimalAPI.Models.Auth;
using AnimalAPI.Models.Util;
using System.Threading.Tasks;

namespace AnimalAPI.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);

    }
}
