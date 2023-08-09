using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit25_EFTraining.Entities;
namespace Unit25_EFTraining.Repositories
{
    public class UserRepository
    {
        private AppContext _context;
        public UserRepository(AppContext context)
        {
            _context = context;
        }
        public User GetUserById(int id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList(); 
        }
        public bool AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool DeleteUser(User user)
        {
            try
            {
                _context.Users.Remove(user);
            }
            catch 
            { 
                return false; 
            }
            return true;
        }
        public bool UpdateUserById(int id, string name)
        {
            try
            {
                var user = GetUserById(id);
                user.Name = name;
                _context.SaveChanges();
            }
            catch
            { 
                return false; 
            }
            return true;
        }
        public bool TakeBook(User user, Book book)
        {
            try
            {
                if (book.UserId != 0)
                    throw new Exception();
                user.Books.Add(book);
                book.UserId = user.Id;
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public int GetUserBooksCount(User user)
        {
            return user.Books.Count;
        }

        public bool DoUserTakeBook(User user, Book book)
        {
            return user.Books.Contains(book);
        }
    }
}
