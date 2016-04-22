using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}