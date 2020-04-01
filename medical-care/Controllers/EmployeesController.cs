using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using medical_care.App_Start;
using medical_care.Data;
using medical_care.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;


namespace medical_care.Controllers
{
    public class EmployeesController : Controller
    {
        private MyDbContext db = new MyDbContext();
        private ApplicationUserManager _userManager;

        public EmployeesController()
        {

        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        public MyDbContext MyDbContext
        {
            get
            {
                return db ?? HttpContext.GetOwinContext().GetUserManager<MyDbContext>();
            }
            private set
            {
                db = value;
            }
        }

        public ActionResult Register()
        {
            return View("Create");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string username, string email, string password, string firstname, string lastname, string address, string phone, string city)
        {
            if (ModelState.IsValid)
            {
                var account = new Employee()
                {
                    UserName = username,
                    Email = email,
                    Firstname = firstname,
                    Lastname = lastname,
                    //Password = password,
                    Address = address,
                    City = city,
                    Phone = phone,
                    EmpStatus = Models.EmpStatus.NORMAL
                };

                IdentityResult result = await UserManager.CreateAsync(account, password);
                Debug.WriteLine("@@@" + result.Succeeded);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(account.Id, "employee");
                    //var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
                    //var userIdentity = await UserManager.CreateIdentityAsync(account, DefaultAuthenticationTypes.ApplicationCookie);
                    //authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                    //string code = await UserManager.GenerateEmailConfirmationTokenAsync(account.Id);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = account.Id, code = code }, protocol: Request.Url.Scheme);
                    //await UserManager.SendEmailAsync(account.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    //ViewBag.Message =
                    //    "Chúng tôi đã gửi email xác thực đến tài khoản của bạn. Kiểm tra email của bạn để thực hiện xác thực.";


                    return View("Login");
                }
                else
                {
                    Debug.WriteLine("@@@");

                    Debug.WriteLine(JsonConvert.SerializeObject(result.Errors));
                }

            }

            return View("Login");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = UserManager.Find(username, password);
            //if (user != null)
            //{
            //    var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            //    var userIdentity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            //    authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
            //    //return Redirect("/Home");
            //}
            //else
            //{
            //    Debug.WriteLine("@@@");

            //    Debug.WriteLine(JsonConvert.SerializeObject(HttpNotFound()));
            //}

            //var role = db.Roles.Where(r => r.Name == "employee");
            if (user == null)
            {
                Debug.WriteLine("@@@");

                Debug.WriteLine(JsonConvert.SerializeObject(HttpNotFound()));
                return HttpNotFound();
            }
            //else if (user != null && Roles.IsUserInRole(username, "admin"))
            //{
            //    bool result = User.IsInRole("admin");
            //    // success
            //    var ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            //    //use the instance that has been created. 
            //    var authManager = HttpContext.GetOwinContext().Authentication;
            //    authManager.SignIn(
            //        new AuthenticationProperties { IsPersistent = false }, ident);
            //    return Redirect("/ManageUser");
            //}

            // success
            var ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            //use the instance that has been created. 
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);

            return Redirect("/PolicyClient");
        }

        [AllowAnonymous]
        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(string username, string password)
        {
            var admin = UserManager.Find(username, password);
            
            //var role = db.Roles.Where(r => r.Name == "admin");

            //bool result = User.IsInRole("admin");

            if (admin != null && UserManager.IsInRole(admin.Id, "admin"))
            {
                //bool result = User.IsInRole("admin");
                // success
                var ident = UserManager.CreateIdentity(admin, DefaultAuthenticationTypes.ApplicationCookie);
                //use the instance that has been created. 
                var authManager = HttpContext.GetOwinContext().Authentication;
                authManager.SignIn(
                    new AuthenticationProperties { IsPersistent = false }, ident);
                return Redirect("/ManageUser");
            }

            Debug.WriteLine(admin + "@@@");
            Debug.WriteLine(JsonConvert.SerializeObject(HttpNotFound()));
            return HttpNotFound();
        }

        public ActionResult Logout()
        {
            var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return Redirect("/PolicyClient");
        }

        //GET: Employees
        //public ActionResult Index()
        //{
        //    return View(db.Employees.ToList());
        //}

        //// GET: Employees/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employee);
        //}

        ////GET: Employees/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Employees/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ValidateInput(false)]

        //public ActionResult Create([Bind(Include = "EmployeeId,Firstname,Lastname,Username,Password,Address,Phone,City,Country,CreatedAt,UpdatedAt,DeletedAt,UpdatedBy,EmpStatus")] Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Employees.Add(employee);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(employee);
        //}

        ////GET: Employees/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employee);
        //}

        //// POST: Employees/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ValidateInput(false)]

        //public ActionResult Edit([Bind(Include = "EmployeeId,Firstname,Lastname,Username,Password,Address,Phone,City,Country,CreatedAt,UpdatedAt,DeletedAt,UpdatedBy,EmpStatus")] Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(employee).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        //// GET: Employees/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employee employee = db.Employees.Find(id);
        //    if (employee == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employee);
        //}

        //// POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Employee employee = db.Employees.Find(id);
        //    db.Employees.Remove(employee);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
