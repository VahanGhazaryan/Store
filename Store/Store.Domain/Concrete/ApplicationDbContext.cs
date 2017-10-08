using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Store.Domain.Entities;
using Store.Domain.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Concrete
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        
        public ApplicationDbContext() : base("ApplicationDbContext")
        {
           
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<ProductProperty> ProductProproties { get; set; }
        public DbSet<ProductPropertyValue> ProductProprotyValues { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
       
    }

    //public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    //{
    //    protected override void Seed(Store.Domain.Concrete.ApplicationDbContext context)
    //    {
    //        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
    //        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

    //        var role1 = new IdentityRole { Name = "admin" };
    //        var role2 = new IdentityRole { Name = "user" };

    //        roleManager.Create(role1);
    //        roleManager.Create(role2);

    //        var admin = new ApplicationUser { Email = "vahanlsoft@gmail.com", UserName = "admin" };
    //        string password = "admin";
    //        var result = userManager.Create(admin, password);

    //        if (result.Succeeded)
    //        {
    //            userManager.AddToRole(admin.Id, role1.Name);
    //            userManager.AddToRole(admin.Id, role2.Name);
    //        }
    //        base.Seed(context);
    //      
    //    }
    //}

    
}
