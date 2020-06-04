using IceCreamShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace IceCreamShopDatabaseImplement
{
    public class IceCreamShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
               optionsBuilder.UseSqlServer(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=IceCreamShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Ingredient> Ingredients { set; get; }
        public virtual DbSet<IceCream> IceCreams { set; get; }
        public virtual DbSet<IceCreamIngredient> IceCreamIngredients { set; get; }
        public virtual DbSet<Booking> Bookings { set; get; }
        public virtual DbSet<StorageIngredient> StorageIngredients { set; get; }
        public virtual DbSet<Storage> Storages { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
    }
}

