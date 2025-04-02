using ManagerStudent.Models;

namespace ManagerStudent.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetByUsername(string username);
        bool Exists(string username);
    }
}
