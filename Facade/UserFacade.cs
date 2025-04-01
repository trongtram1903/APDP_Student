using ManagerStudent.Models;
using ManagerStudent.Repository;
using BCrypt.Net;
using ManagerStudent.Repository.ManagerStudent.Repository;
namespace ManagerStudent.Facade
{
    namespace ManagerStudent.Facade
    {
        public class UserFacade : IUserFacade
        {
            private readonly IUserRepository _userRepository;

            public UserFacade(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public bool RegisterUser(string username, string password, string fullName, string email)
            {
                if (_userRepository.Exists(username))
                    return false; // Tài khoản đã tồn tại

                var user = new User
                {
                    Username = username,
                    Password = BCrypt.Net.BCrypt.HashPassword(password), // Bảo mật mật khẩu
                    FullName = fullName,
                    Email = email,
                    RoleId = 1

                };

                _userRepository.Add(user);
                return true; // Đăng ký thành công
            }

        public User AuthenticateUser(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user; // Đăng nhập thành công
            }
            return null; // Sai thông tin đăng nhập
        }

        public void RegisterUser(User user)
        {
            // Mặc định RoleId là 3 (Student)
            user.RoleId = 3;

            // Mã hóa mật khẩu trước khi lưu
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _userRepository.Add(user);
        }

        }

    }
}
