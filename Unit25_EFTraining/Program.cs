using Unit25_EFTraining.Entities;
using Unit25_EFTraining.Repositories;

namespace Unit25_EFTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var User1 = new User { Name = "Andrey", Email = "An@mail.com" };
                var User2 = new User { Name = "Viktor", Email = "Vi@mail.com"};
                var Book1 = new Book { Name = "Brain", Created = new DateTime(2008, 3, 1)};
                var Book2 = new Book { Name = "Identy", Created = new DateTime(1992,2,2)};
                var BookRepository = new BookRepository(db);
                var UserRepository = new UserRepository(db);
                UserRepository.AddUser(User1);
                UserRepository.AddUser(User2);
                BookRepository.AddBook(Book1);
                BookRepository.AddBook(Book2);
                db.SaveChanges();
                UserRepository.UpdateUserById(1, "Markus");
                BookRepository.UpdateBookById(1, "2001/1/1");
                var Users = UserRepository.GetAllUsers();
                var Books = BookRepository.GetAllBooks();
                foreach (var User in Users)
                {
                    Console.WriteLine(User.Name);
                }
                foreach (var Book in Books)
                {
                    Console.WriteLine(Book.Name);
                }

                UserRepository.UpdateUserById(1, "Markus");
                BookRepository.UpdateBookById(1, "Moon");

            }
        }
    }
}