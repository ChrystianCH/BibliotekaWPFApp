using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    public class BibliotekaDb : DbContext
    {
        public BibliotekaDb()
        {
            Database.EnsureCreated();

            if(!Categories.Any())
            {
                Categories.Add(new Category("Powieść"));
                Categories.Add(new Category("Kryminał"));
                Categories.Add(new Category("Historia"));
                Categories.Add(new Category("Nauka"));
                this.SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BibliotekaApp;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
    }
}
