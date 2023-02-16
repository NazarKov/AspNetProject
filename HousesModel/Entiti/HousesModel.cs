using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousesModel.Entiti
{
    public class Houses
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string addres { get; set; }
        public string nomerHouse { get; set; }
        public string Description { get; set; }
        public string price { get; set; }
        public string photo { get; set; }
        public string rec { get; set; }
        public Categori categori { get; set; }
    }
    public class Categori
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string ico { get; set; }
        public ICollection<Houses> Houses { get; set;}
        public Categori()
        {
            Houses = new List<Houses> ();
        }
    }
    public class User
    {
        public int ID { get; set; }

        public string Login { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string password { get; set; }

    }

    public class orders
    {
        public int ID { get; set; }

        public User id_user { get; set; }
        public Houses id_house { get; set; }
        public string stasus { get; set; }

    }

}
