using HousesModel.Concreate;
using HousesModel.Entiti;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace houses.Controllers
{
    public class LoginUserController : Controller
    {
    
        DbHousesContext db = null;
        List<User> users = null;
        public LoginUserController()
        {
            db = new DbHousesContext();
            db.users.Load();
            users = new List<User>();
            users = db.users.Local.ToList();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public RedirectResult registration_user(string userName,string userlastname,string userLogin,string userPassword ,string userEmail,string userPhone)
        {

            db.users.Add(new User { name = userName + " " + userlastname, Login = userLogin, Email = userEmail, password = userPassword, phone = userPhone, Role = "1" });
            db.SaveChanges();

            return Redirect("~/LoginUser/Index");
        }
        [HttpPost]
        public RedirectResult autorization(string userLogin , string userPassword)
        {
            db = new HousesModel.Concreate.DbHousesContext();
            db.users.Load();
            users = db.users.Local.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                if(users[i].Login==userLogin)
                {
                    if(users[i].password==userPassword)
                    {
                        Session["login"] = userLogin;
                        return Redirect("~/Home/Profile");
                    }
                }
            }

            return Redirect("~/LoginUser/Index");
        }
        public RedirectResult Exit()
        {
            Session["login"] = null;
            return Redirect("~/Home/index");
        }
        public ActionResult ViewEmail()
        {
            return View();
        }
        public ActionResult ViewPassword()
        {
            return View();
        }
        public ActionResult ViewPhone()
        {
            return View();
        }
        public ActionResult ViewPhoto()
        {
            return View();
        }
        [HttpPost]
        public RedirectResult changeEmil(string userEmail)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if(users[i].Login==Session["login"].ToString())
                {
                    users[i].Email = userEmail;
                }
            }
            db.SaveChanges();
            return Redirect("~/Home/Profile");
        }
        [HttpPost]
        public RedirectResult changePhone(string userPhone)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Login == Session["login"].ToString())
                {
                    users[i].phone = userPhone;
                }
            }
            db.SaveChanges();
            return Redirect("~/Home/Profile");
        }
        [HttpPost]
        public RedirectResult changePassword(string userPassword)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Login == Session["login"].ToString())
                {
                    users[i].password = userPassword;
                }
            }
            db.SaveChanges();
            return Redirect("~/Home/Profile");
        }

        [HttpPost]
        public RedirectResult Upload(HttpPostedFileBase upload)
        {
            string fileName="";
            if (upload != null)
            {
                // получаем имя файла
                fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Media/DatabasePhoto/" + fileName));
            }



            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Login == Session["login"].ToString())
                {
                    users[i].photo = fileName;
                }
            }
            db.SaveChanges();
            return Redirect("~/Home/Profile");
        }
    }
}