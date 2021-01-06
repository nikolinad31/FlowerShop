using System;
using System.Collections.Generic;
using System.Text;
using FlowerShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Flower> Flower {get;set;}
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
