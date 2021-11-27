
using System.Threading.Tasks;
using ToDo.Models;

namespace DNP.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string Password);
    }
}