using ManagerStudent.Data;
using ManagerStudent.Models;

namespace ManagerStudent.Repository
{
    namespace ManagerStudent.Repository
    {
        public class UserRepository : IUserRepository
        {
            private readonly ApplicationDbContext _context;

            public UserRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public void Add(User user)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            public User GetByUsername(string username)
            {
                return _context.Users.FirstOrDefault(u => u.Username == username);
            }

            public bool Exists(string username)
            {
                return _context.Users.Any(u => u.Username == username);
            }

        
        }
    }

}
