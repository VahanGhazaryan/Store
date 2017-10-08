using Common;
using Store.DAL.Abstract;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Concrete
{
    public class StoreDBInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            IList<ProductCategory> defaultCategory = new List<ProductCategory>();
            defaultCategory.Add(new ProductCategory() { Id = 1, Name = "Organic Products" });
            defaultCategory.Add(new ProductCategory() { Id = 2, Name = "Meat Products" });
            defaultCategory.Add(new ProductCategory() { Id = 3, Name = "Fish and Seafood" });
            defaultCategory.Add(new ProductCategory() { Id = 3, Name = "Frozen Products" });
            defaultCategory.Add(new ProductCategory() { Id = 3, Name = "Sweets" });

            foreach (var category in defaultCategory)
                context.ProducCategories.Add(category);

            IList<Product> defaultProduct = new List<Product>();
            defaultProduct.Add(new Product() { ProductId = 1, Name = "Cabbage", Description = "Vegetable plants", Price = 16, ImageSrc = "~/Images/6000191272109.jpg", CategoryId = 1 });
            defaultProduct.Add(new Product() { ProductId = 2, Name = "Corn", Description = "Vegetable plants", Price = 20, ImageSrc = "~/Images/Corn.jpg", CategoryId = 1 });
            defaultProduct.Add(new Product() { ProductId = 3, Name = "Tomato", Description = "Vegetable plants", Price = 25, ImageSrc = "~/Images/Tomato.jpg", CategoryId = 1 });
            defaultProduct.Add(new Product() { ProductId = 4, Name = "Radish", Description = "Vegetable plants", Price = 30, ImageSrc = "~/Images/Radish.jpg", CategoryId = 1 });
            defaultProduct.Add(new Product() { ProductId = 5, Name = "Pre-Cooked Sausage", Description = "Sausage", Price = 16, ImageSrc = "~/Images/PreCookedSausage.jpg", CategoryId = 2 });
            defaultProduct.Add(new Product() { ProductId = 6, Name = "Cow", Description = "Sausage", Price = 16, ImageSrc = "~/Images/CowMeat.jpg", CategoryId = 2 });


            foreach (var product in defaultProduct)
                context.Products.Add(product);



            context.Users.Add(new User { UserId = "admin", Password = Helper.HashSha256("admin123") });

            base.Seed(context);
        }
    }

    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=EFDbContext")
        {
            Database.SetInitializer(new StoreDBInitializer());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductCategory> ProducCategories { get; set; }


    }
}
