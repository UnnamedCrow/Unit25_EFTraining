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
                var Book1 = new Book { Name = "Brain", Created = new DateTime(2008, 3, 1), Author = "Savel'ev", Genre = "Science"};
                var Book2 = new Book { Name = "Identy", Created = new DateTime(1992, 2, 2), Author = "Engels", Genre = "Politics"};
                var Book3 = new Book { Name = "Genius", Created = new DateTime(2000, 4, 25), Author = "Savel'ev", Genre = "Science" };
                var Book4 = new Book { Name = "Sorting", Created = new DateTime(2004, 12, 20), Author = "Savel'ev", Genre = "Science" };
                var BookRepository = new BookRepository(db);
                var UserRepository = new UserRepository(db);
                UserRepository.AddUser(User1);
                UserRepository.AddUser(User2);
                BookRepository.AddBook(Book1);
                BookRepository.AddBook(Book2);
                BookRepository.AddBook(Book3);
                BookRepository.AddBook(Book4);
                UserRepository.TakeBook(User1, Book2);
                UserRepository.TakeBook(User1, Book1);
                UserRepository.TakeBook(User1, Book3);
                UserRepository.TakeBook(User2, Book4);

                db.SaveChanges();
                var Users = UserRepository.GetUserBooksCount(User1);
                

                Console.WriteLine(Users);


            }
        }
    }
}