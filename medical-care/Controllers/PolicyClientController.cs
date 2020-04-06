using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using medical_care.Data;
using medical_care.Models;
using Microsoft.AspNet.Identity;

namespace medical_care.Controllers
{
    public class PolicyClientController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: PolicyClient
        public ActionResult Index()
        {
            var policies = db.Policies.Include(p => p.Company).Include(p => p.Hospital);
            return View(policies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }
        
        // GET: Hospitals/Details/5
        public ActionResult HospitalDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        [Authorize]
        public ActionResult Order(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var policy = db.Policies.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        public ActionResult AddRequest()
        {
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        [ActionName("AddRequest")]
        public ActionResult AddRequestConfirm(int? id, string dateRange)
        {
            if (ModelState.IsValid)
            {
                var policy = db.Policies.Find(id);
                var startDate = DateTime.Now;
                var endDate = DateTime.Now.AddYears(1);
                try
                {
                    var dateSplit = dateRange.Split('-');
                    if (dateSplit.Length != 2)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "bad Flower");
                    }
                    startDate = DateTime.ParseExact(dateSplit[0], "MM/DD/YYYY", null);
                    endDate = DateTime.ParseExact(dateSplit[1], "MM/DD/YYYY", null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                var policyRq = new PolicyOnEmp()
                {
                    PolicyId = policy.PolicyId,
                    EmployeeId = (HttpContext.User.Identity.GetUserId()),
                    RequestDate = DateTime.Now,
                    PolicyDuration = policy.Duration,
                    PolicyAmount = policy.Amount,
                    PolicyName = policy.Name,
                    PolicyStart = startDate,
                    PolicyEnd = endDate,
                    CompanyName = policy.Company.Name,
                    HospitalName = policy.Hospital.Name,
                    Status = PolOnEmpStatus.PENDING
                };
                db.PolicyOnEmps.Add(policyRq);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "PolicyClient");
        }

        // GET: Employees/Details/5
        public ActionResult EmployeeDetails(string id)
        {
            if (id == null)
            {
                return Redirect("/Employees/Login");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = db.Employees.Find(id);
            var user = new Employee()
            {
                UserName = employee.UserName,
                Firstname = employee.Firstname,
                Lastname = employee.Lastname,
                Phone = employee.Phone,
                City = employee.City,
                Address = employee.Address,
            };
            Session.Add("CurrentUser", user);
            
            return View(employee);
        }

        //GET: Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var employee = db.Employees.Find(id);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit([Bind(Include = "EmployeeId,Firstname,Lastname,Username,Address,Phone,City")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //GET: PolicyOnEmps
        //public ActionResult PolicyOnEmp(string id)
        //{
        //    var policyOnEmps = db.PolicyOnEmps.Where(p => p.EmployeeId == id);
            
        //    if (policyOnEmps != null)
        //    {
        //    }
        //    return View(policyOnEmps);
        //}
    }
}