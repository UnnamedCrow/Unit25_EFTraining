using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit25_EFTraining.Entities;

namespace Unit25_EFTraining
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }
        //Объекты таблицы Books
        public DbSet<Book> Books { get; set; }
        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = User-PC\SQLEXPRESS; DataBase = Library; Trusted_Connection = True;Trust Server Certificate = True ");
        }
    }
}
