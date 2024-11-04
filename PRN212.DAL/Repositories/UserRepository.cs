using PRN212.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN212.DAL.Repositories
{
    public class UserRepository
    {
        private ToDoAppDbContext _context;

        public User? GetUser(string email, string password)
        {
            _context = new ToDoAppDbContext();
            return _context.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password); ;
        }

        public bool CheckUser(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username || u.Email == user.Email))
            {
                return false;
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public void Add(User u)
        {
            _context = new ToDoAppDbContext();
            _context.Users.Add(u);
            _context.SaveChanges();
        }

        public async Task<DAL.Models.Task?> FindAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }



    }
}
