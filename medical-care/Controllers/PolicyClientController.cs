using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using medical_care.Data;
using medical_care.Models;

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


        public ActionResult Add(int? id)
        {
            
                if (ModelState.IsValid)
                {
                    var policy = db.Policies.Find(id);
                    
                    var policyRq = new PolicyRequest()
                    {
                        PolicyId = policy.PolicyId,
                        EmployeeId = 1,
                        RequestDate = DateTime.Now,
                        Emi   = policy.Emi,
                        
                    };
                db.PolicyRequests.Add(policyRq);
                db.SaveChanges();
                
            }
                return RedirectToAction("Index", "PolicyRequests");
            //return View(policyRq);
        }
    }
}