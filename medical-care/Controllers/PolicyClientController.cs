using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult AddRequestConfirm(int? id)
        {
            if (ModelState.IsValid)
            {
                var policy = db.Policies.Find(id);

                var policyRq = new PolicyRequest()
                {
                    PolicyId = policy.PolicyId,
                    Id = (HttpContext.User.Identity.GetUserId()),
                    RequestDate = DateTime.Now,
                    Amount = policy.Amount,
                    PolicyName = policy.Name,
                    CompanyName = policy.Company.Name
                };
                db.PolicyRequests.Add(policyRq);
                db.SaveChanges();

            }
            return RedirectToAction("Index", "PolicyClient");
            //return View(policyRq);
        }

        // GET: PolicyOnEmps
        //public ActionResult PolicyOnEmp()
        //{
        //    var policyOnEmps = db.PolicyOnEmps.Include(p => p.Employee.Id).Include(p => p.Policy);
        //    return View(policyOnEmps.ToList());
        //}
    }
}