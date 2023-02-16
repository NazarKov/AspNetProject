using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using houses.Models;
using HousesModel.Abstract;
using HousesModel.Entiti;
using HousesModel.Concreate;
using System.Data.Entity;

namespace houses.Controllers
{
    public class HomeController : Controller
    {
        //private IHouseReposetory reposetory;
        private DbHousesContext db = null;
        private List<Categori> categoris = null;
        private List<Houses> houses = null;
        private List<Houses> temp = null;
        private List<User> users = null;
        private List<orders> orders1 = null;
        public HomeController()
        {
           
            db = new DbHousesContext();
            categoris = new List<Categori>();
            houses = new List<Houses>();
            users = new List<User>();
            orders1 = new List<orders>();
            db.users.Load();
            db.Categoris.Load();
            db.Houses.Load();
            db.orders.Load();
            categoris = db.Categoris.Local.ToList();
            houses = db.Houses.Local.ToList();
            users = db.users.Local.ToList();
            orders1 = db.orders.Local.ToList();
        }

        public ActionResult Index()
        {
            ViewBag.cat1 = categoris.ElementAt(0);
            ViewBag.cat2 = categoris.ElementAt(1);
            ViewBag.cat3 = categoris.ElementAt(2);
            ModelListHouse model = new ModelListHouse
            {
                houses = db.Houses
            };
            return View(model);
        }

        public ActionResult About()
        {
            #region
            if (Request.Cookies.Get("text")==null)
            {
                HttpCookie cookie = new HttpCookie("text");
                cookie.Value = "0";
                Request.Cookies.Add(cookie);
            }
            #endregion
            ModelListHouse model = null;
            if (Request.QueryString["Search"] == null)
            {
                if (Request.QueryString["category"] == "all")
                {
                    model = new ModelListHouse
                    {
                        houses = houses
                    };
                    return View(model);
                }
                else if (Request.QueryString["category"] == "Квартира")
                {
                    temp = new List<Houses>();
                    for (int i = 0; i < houses.Count; i++)
                    {
                        if (houses.ElementAt(i).categori.name == Request.QueryString["category"])
                        {
                            temp.Add(houses.ElementAt(i));
                        }
                    }

                    model = new ModelListHouse
                    {
                        houses = temp
                    };
                    return View(model);
                }
                else if (Request.QueryString["category"] == "Будинок")
                {
                    temp = new List<Houses>();
                    for (int i = 0; i < houses.Count; i++)
                    {
                        if (houses.ElementAt(i).categori.name == Request.QueryString["category"])
                        {
                            temp.Add(houses.ElementAt(i));
                        }
                    }

                    model = new ModelListHouse
                    {
                        houses = temp
                    };
                    return View(model);
                }
                else if (Request.QueryString["category"] == "Офісне приміщення")
                {
                    temp = new List<Houses>();
                    for (int i = 0; i < houses.Count; i++)
                    {
                        if (houses.ElementAt(i).categori.name == Request.QueryString["category"])
                        {
                            temp.Add(houses.ElementAt(i));
                        }
                    }

                    model = new ModelListHouse
                    {
                        houses = temp
                    };
                    return View(model);
                }
            }
            else
            {
                temp = new List<Houses>();
                for (int i = 0; i < houses.Count; i++)
                {
                    if (houses.ElementAt(i).name == Request.QueryString["Search"])
                    {
                        temp.Add(houses.ElementAt(i));
                    }
                }

                model = new ModelListHouse
                {
                    houses = temp
                };
                return View(model);
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Profile()
        {
            if(Session["login"]==null)
            {
                return Redirect("~/LoginUser/index");
            }
            for (int i = 0; i < users.Count; i++)
            {
                if(users[i].Login==Session["login"].ToString())
                {
                    ModelUser model = new ModelUser
                    {
                        user = users[i]
                    };
                    return View(model);
                }
            }
            return View();
        }
        public ActionResult Product()
        {

            for (int i = 0; i < houses.Count; i++)
            {
                if (houses.ElementAt(i).name == Request.QueryString["name"])
                {
                    ModelHouse model = new ModelHouse
                    {
                        Houses = houses.ElementAt(i)
                    };
                     return View(model);
                }
            }
        
            return View();
        }
        public ActionResult order()
        {
            if (Session["login"] == null)
            {
                return Redirect("~/LoginUser/index");
            }
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Login == Session["login"].ToString())
                {
                    ModelUser model = new ModelUser
                    {
                        user = users[i]
                    };
                    return View(model);
                }
            }
            return View();
        }
        public ActionResult addorder(string userN , string userEmail ,string userPhone,string house)
        {
            orders orders = new orders();
            for (int i = 0; i < houses.Count; i++)
            {
                if(house==houses[i].name)
                {
                    orders.id_house = houses[i];
                    break;
                }
            }
            for (int i = 0; i < users.Count; i++)
            {
                if(userN==users[i].name)
                {
                    orders.id_user = users[i];
                    break;
                }
            }
            orders.stasus = "Опрацьовується";
            db.orders.Add(orders);
            db.SaveChanges();
            return Redirect("~/Home/FinOrder");
        }
        public ActionResult FinOrder()
        {

            return View();
        }
        public ActionResult UserOrderList()
        {
            string name=" ";
            if (Session["login"] == null)
            {
                return Redirect("~/LoginUser/index");
            }
            else
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Login == Session["login"].ToString())
                    {
                        name = users[i].name;
                        break;
                    }
                }
                List<orders> orderstemp = new List<orders>();
                for (int i = 0; i < orders1.Count; i++)
                {
                    if (orders1[i].id_user.name == name)
                    {
                        orderstemp.Add(orders1[i]);
                    }
                }
                ModelOrdersList model = new ModelOrdersList
                {
                    orders = orderstemp
                };
                return View(model);
            }
        }
    }
}