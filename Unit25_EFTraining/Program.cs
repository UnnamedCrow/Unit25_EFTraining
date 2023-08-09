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
                UserRepository.TakeBook(User1, Book2);
                UserRepository.TakeBook(User1, Book1);
                UserRepository.TakeBook(User2, Book1);
                db.SaveChanges();
                var Users = UserRepository.GetAllUsers();
                var Books = BookRepository.GetAllBooks();

                foreach (var User in Users)
                {
                    Console.WriteLine(User.Name);
                    foreach (var Book in User.Books)
                    {
                        Console.WriteLine(Book.Name);
                    }
                    Console.WriteLine("?????????????");
                }


            }
        }
    }
}