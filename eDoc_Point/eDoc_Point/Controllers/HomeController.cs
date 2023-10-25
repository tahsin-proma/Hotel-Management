using DatabaseLayer;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace eDoc_Point.Controllers
{
    public class HomeController : Controller
    {
        private OnlineDiagnosticLabSystemDbEntities db = new OnlineDiagnosticLabSystemDbEntities();
        public ActionResult Index()
        {
            if(string.IsNullOrEmpty(Convert.ToString(Session["UserName"])))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult StartTemplate()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String email, string password)
        {

            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                return View("Login");
            }

            var user = db.UserTables.Where(u => u.Email == email && u.Password == password && u.IsVerified == true).FirstOrDefault();
            if (user != null)
            {
                Session["UserID"] = user.UserID;
                Session["UserTypeID"] = user.UserTypeID;
                Session["UserName"] = user.UserName;
                Session["Password"] = user.Password;
                Session["Email"] = user.Email;
                Session["ContactNo"] = user.ContactNo;
                Session["Description"] = user.Description;
                Session["IsVerified"] = user.IsVerified;
                return View("Index");
            }
            Logout();
            return View("Login");
        }
        public void Logout()
        {
            Session["UserID"] = string.Empty;
            Session["UserTypeID"] = string.Empty;
            Session["UserName"] = string.Empty;
            Session["Password"] = string.Empty;
            Session["Email"] = string.Empty;
            Session["ContactNo"] = string.Empty;
            Session["Description"] = string.Empty;
            Session["IsVerified"] = string.Empty;
           
        }


        public ActionResult ChangePassword()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string OldPassword,string NewPassword,string ConfirmPassword)
        {
            if(Session["UserID"]== null)
            {
                return RedirectToAction("Login", "Home");
            }
            int? userid = Convert.ToInt32(Session["UserID"].ToString());
            UserTable users = db.UserTables.Find(userid);
            if(users.Password == OldPassword)
            {
                if(NewPassword == ConfirmPassword)
                {
                    users.Password = NewPassword;
                    db.Entry(users).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.message = "Change Successfully!";
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ViewBag.message = "New Password and Confirm Password Not Matched!";
                    return View("ChangePassword");
                }
            }
            else
            {
                ViewBag.message = "Old  Password is Incorrect";
                return View("ChangePassword");
            }
            
        }

        public ActionResult CreateUser()
        {
            ViewBag.UserTypeID = new SelectList(db.UserTypeTables.Where(u => u.UserTypeID != 1), "UserTypeID", "UserType", "0");

            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(UserTable user)
        {

            if(user != null)
            {
                if(ModelState.IsValid)
                { 
                    var finduser = db.UserTables.Where(u => u.Email == user.Email).FirstOrDefault();
                    if(finduser == null)
                    {
                        finduser = db.UserTables.Where(u => u.Email == user.Email && u.IsVerified == false).FirstOrDefault();
                        if(finduser == null)
                        {
                            if (user.UserTypeID == 2) //Doctor
                            {
                                user.IsVerified = true;
                            }
                            else if (user.UserTypeID == 3) //Lab
                            {
                                user.IsVerified = false;
                            }
                            else if (user.UserTypeID == 4) //Patient
                            {
                                user.IsVerified = false;
                            }
                            else if (user.UserTypeID == 1) //Admin
                            {
                                user.IsVerified = false;
                            }

                            db.UserTables.Add(user);
                            db.SaveChanges();
                            Session["User"] = user;

                            if (user.UserTypeID == 2) //Doctor
                            {
                                return View("AddDoctor");
                            }
                            else if (user.UserTypeID == 3) //Lab
                            {
                                return View("AddLab");
                            }
                            else if (user.UserTypeID == 4) //Patient
                            {
                                return View("AddPatient");
                            }
                            else if (user.UserTypeID == 1) //Admin
                            {
                                ViewBag.Message = "Account is Under Review!";
                            }

                            

                        }
                        else
                        {
                            ViewBag.Message = "Account is Under Review!";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Email already registered!";
                    }

                }
            }
            else
            {
                ViewBag.Message = "Please provide Content Details!";
            }
            ViewBag.UserTypeID = new SelectList(db.UserTypeTables.Where(u => u.UserTypeID != 1), "UserTypeID", "UserType", "0");
            return View("CreateUser");
        }
        public ActionResult AddDoctor()
        {

            return View();
        }
        [HttpPost]

        public ActionResult AddDoctor(DoctorTable doctor)
        {
            return View();
        }

        public ActionResult AddLab()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLab(LabTable lab)
        {
            return View();
        }

        public ActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPatient(PatientTable patient)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}