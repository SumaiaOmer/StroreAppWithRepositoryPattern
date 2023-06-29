using Microsoft.EntityFrameworkCore;
using StoreWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreWebApp.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }

       public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Favorite> favorite { get; set; }

    }
}
