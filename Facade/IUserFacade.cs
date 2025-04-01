using ManagerStudent.Models;
namespace ManagerStudent.Facade
{
    public interface IUserFacade
    {
        bool RegisterUser(string username, string password, string fullName, string email);
        User AuthenticateUser(string username, string password);
        void RegisterUser(User user);
    }
}
