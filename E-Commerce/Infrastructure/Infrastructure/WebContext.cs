﻿using Backend_ECommerce_App.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options)
    : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
