using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using HousesModel.Entiti;

namespace HousesModel.Concreate
{
    public class DbHousesContext : DbContext
    {
        public DbSet<Houses> Houses { get; set; }
        public DbSet<Categori> Categoris { get; set; }
        public DbSet<User> users { get; set; }
        
        public DbSet<orders> orders { get; set; }
        public DbHousesContext()
        {
            Database.SetInitializer(new DbHouseContextInitializer());
        }
    }
    public class DbHouseContextInitializer : DropCreateDatabaseIfModelChanges<DbHousesContext>
    {
        protected override void Seed(DbHousesContext context)
        {
            context.Categoris.Add(new Categori { name = "Будинок" , photo="House.jpg" });
            context.Categoris.Add(new Categori { name = "Квартира" ,photo="kvart.jpeg"});
            context.Categoris.Add(new Categori { name = "Офісне приміщення" , photo="ofise.jpg" });

            context.SaveChanges();

            context.Houses.Add(new Houses { name = "Будинок 1", addres = "Проспект Волі", nomerHouse = "15", price = "150 000$", Description = "0_0" , rec = "1", photo = "House1.jpg" , categori = new Categori { name = "Будинок", photo = "House.jpg" } });
            context.Houses.Add(new Houses { name = "Будинок 2", addres = "Проспект Волі", nomerHouse = "15", price = "150 000$", Description = "0_0", rec = "1", photo = "House2.jpg", categori = new Categori { name = "Будинок", photo = "House.jpg" } });
            context.Houses.Add(new Houses { name = "Будинок 3", addres = "Проспект Волі", nomerHouse = "15", price = "150 000$", Description = "0_0", rec = "1", photo = "House3.jpg", categori = new Categori { name = "Будинок", photo = "House.jpg" } });
            context.Houses.Add(new Houses { name = "Будинок 4", addres = "Проспект Волі", nomerHouse = "15", price = "150 000$", Description = "0_0" , rec = "1", photo = "House4.jpg" , categori = new Categori { name = "Будинок" , photo="House.jpg" } });
            context.Houses.Add(new Houses { name = "Будинок 5", addres = "Проспект Волі", nomerHouse = "15", price = "150 000$", Description = "0_0" , rec = "1", photo = "House5.jpg" , categori = new Categori { name = "Будинок" , photo="House.jpg" } });
            context.Houses.Add(new Houses { name = "Будинок 6", addres = "Проспект Волі", nomerHouse = "15", price = "150 000$", Description = "0_0" , rec = "1", photo = "House6.jpg" , categori = new Categori { name = "Будинок" , photo="House.jpg" } });
            context.Houses.Add(new Houses { name = "Будинок 11", addres = "Проспект Волі", nomerHouse = "15",price = "150 000$", Description = "0_0", rec = "0", photo = "House11.jpg" , categori = new Categori { name = "Будинок" , photo="House.jpg" } });
            context.Houses.Add(new Houses { name = "Будинок 7", addres = "Проспект Волі", nomerHouse = "15", price = "150 000$", Description = "0_0" , rec = "0", photo = "House7.jpg" , categori = new Categori { name = "Будинок" , photo="House.jpg" } }); 
            context.Houses.Add(new Houses { name = "Будинок 8", addres = "Проспект Волі", nomerHouse = "15", price = "150 000$", Description = "0_0" , rec = "0", photo = "House8.jpg" , categori = new Categori { name = "Будинок" , photo="House.jpg" } });
            context.Houses.Add(new Houses { name = "Будинок 9", addres = "Проспект Волі", nomerHouse = "15", price = "150 000$", Description = "0_0" , rec = "0", photo = "House9.jpg" , categori = new Categori { name = "Будинок" , photo="House.jpg" } });
            context.Houses.Add(new Houses { name = "Будинок 10", addres = "Проспект Волі", nomerHouse = "15",price = "150 000$", Description = "0_0", rec = "0", photo = "House10.jpg" , categori = new Categori { name = "Будинок" , photo="House.jpg" } });
            context.Houses.Add(new Houses { name = "Будинок 12", addres = "Проспект Волі", nomerHouse = "15",price = "150 000$", Description = "0_0", rec = "0", photo = "House12.jpg" , categori = new Categori { name = "Будинок", photo = "House.jpg" } });

           //context.memberships.Add(new User { name="назар" , Role="2",password="admin",Email="nazar.korniychuK@Ukt.net" , phone="380996367125" , photo = "admin.png"});


            context.SaveChanges();
        }

    }
}
