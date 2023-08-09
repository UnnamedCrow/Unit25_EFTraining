namespace Unit25_EFTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var User1 = new User { Name = "Andrey", Email = "An@mail.com" };
                var Book1 = new Book { Name = "Brain", Created = new DateTime(2008, 3, 1) };
                db.Users.Add(User1);
                db.Books.Add(Book1);
                db.SaveChanges();
            }
        }
    }
}