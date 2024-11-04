using PRN212.DAL.Models;
using PRN212.DAL.Repositories;

namespace PRN212.BLL.Services
{
    public class UserService
    {
        private UserRepository _repo = new();

        public User? GetOne(string email, string password)
        {
            return _repo.GetUser(email, password);
        }

        public bool CheckUserExist(User user) { 
            return _repo.CheckUser(user);
        }

        public void AddUser(User user) { 
            _repo.Add(user);
        }
    }
}
