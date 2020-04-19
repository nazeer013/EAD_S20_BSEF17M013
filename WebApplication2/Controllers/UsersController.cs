using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Entities;
using BAL;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{


    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Main()
        {
            Session["FolderID"] = 0;
            return View();
        }
        [HttpPost]
        [ActionName("Main")]
        public ActionResult Main2()
        { 
            return View();
        }
        [HttpPost]
        public JsonResult GetFolders(int ID)
        {
            List<Folders> l1 = new List<Folders>();
            l1 = BAL.BAL.GetFolders(ID);
            Session["FolderID"] = ID;
            return Json(l1, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CreateFolder(string Name)
        {
            int ID =(int) Session["FolderID"];
            int id1 = BAL.BAL.CreateFolder(ID, Name);
            return Json(id1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult OpenParentFolder()
        {
            int Child =(int) Session["FolderID"];
            int Parent = BAL.BAL.ReturnParent(Child);
            List<Folders> l1 = new List<Folders>();
            l1 = BAL.BAL.GetFolders(Parent);
            Session["FolderID"] = Parent;
            return Json(l1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Users()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login2()
        {
            string Login = Request["Login"];
            string Password = Request["Password"];
            //DataBase Logic
            string connString = @"Data Source=.\SQLEXPRESS2012;Initial Catalog = Assignment3;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlQuery = "Select Password from Users where Login='" + Login + "'";
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read() == true)
            {
                string password1 = (string)reader.GetValue(0);
                if (password1 == Password)
                {
                    conn.Close();
                    return Redirect("~/Users/Main");
                }
                else
                {
                    conn.Close();
                    ViewBag.ErrorMsg = "Invalid Password";
                    return View("Login");
                }
            }
            ViewBag.ErrorMsg = "Login does not exist";
            conn.Close();
            return View("Login");
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View("SignUp");
        }
        [HttpPost]
        [ActionName("SignUp")]
        public ActionResult SignUp2()
        {
            string Name = Request["Name"];
            string Login = Request["Login1"];
            string Password = Request["Password1"];
            //DataBase Logic
            string connString = @"Data Source=.\SQLEXPRESS2012;Initial Catalog = Assignment3;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string sqlQuery = "Insert into Users(name,login,password) values('" + Name + "','" + Login + "','" + Password+"');";
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            int recAff = command.ExecuteNonQuery();
            return View("Main");
            //return Redirect("~/Users/SignUp");
        }

        
    }

}