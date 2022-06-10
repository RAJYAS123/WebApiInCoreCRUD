using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreCRUD.DataModels;

namespace WebApiCoreCRUD.DataContext
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BookMaster> bookMasters { get; set; }

        public DbSet<AuthorMaster> AuthorMasters { get; set; }
    }
}
