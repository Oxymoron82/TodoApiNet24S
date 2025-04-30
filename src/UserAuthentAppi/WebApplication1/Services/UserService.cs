using System.Collections.Generic;
using System.Linq;
using UserAuthentAppi.Models;

namespace UserAuthentAppi.Services
{
    public class UserService
    {
        private readonly List<User> _users = new();

        public bool Register(string username, string password)
        {
            if (_users.Any(u => u.Username == username))
                return false; // Пользователь уже существует

            _users.Add(new User(username, password));
            return true;
        }

        public bool Authenticate(string username, string password)
        {
            return _users.Any(u => u.Username == username && u.Password == password);
        }
    }
}
