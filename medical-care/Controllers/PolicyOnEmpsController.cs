using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using medical_care.Data;
using medical_care.Models;

namespace medical_care.Controllers
{
    [Authorize(Roles = "admin")]
    public class PolicyOnEmpsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: PolicyOnEmps
        public ActionResult Index()
        {
            var policyOnEmps = db.PolicyOnEmps.Include(p => p.Employee).Include(p => p.Policy);
            return View(policyOnEmps.ToList());
        }

        // GET: PolicyOnEmps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyOnEmp policyOnEmp = db.PolicyOnEmps.Find(id);
            if (policyOnEmp == null)
            {
                return HttpNotFound();
            }
            return View(policyOnEmp);
        }

        // GET: PolicyOnEmps/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Users, "Id", "Email");
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name");
            return View();
        }

        // POST: PolicyOnEmps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PolicyName,PolicyAmount,PolicyDuration,Emi,PolicyStart,PolicyEnd,CreatedAt,UpdatedAt,DeletedAt,CreatedBy,UpdatedBy,Status,EmployeeId,PolicyId")] PolicyOnEmp policyOnEmp)
        {
            if (ModelState.IsValid)
            {
                db.PolicyOnEmps.Add(policyOnEmp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Users, "Id", "Email", policyOnEmp.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", policyOnEmp.PolicyId);
            return View(policyOnEmp);
        }

        // GET: PolicyOnEmps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyOnEmp policyOnEmp = db.PolicyOnEmps.Find(id);
            if (policyOnEmp == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Users, "Id", "Email", policyOnEmp.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", policyOnEmp.PolicyId);
            return View(policyOnEmp);
        }

        // POST: PolicyOnEmps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PolicyOnEmp policyOnEmp, string dateRange)
        {
            if (ModelState.IsValid)
            {
                //PolicyRequest currentPolicyOnEmp = db.PolicyRequests.Find(policyOnEmp.Id);
                //if (currentPolicyOnEmp == null)
                //{
                //    return new HttpNotFoundResult();
                //}

                //var startDate = DateTime.Now;
                //var endDate = DateTime.Now.AddYears(1);
                //try
                //{
                //    var dateSplit = dateRange.Split('-');
                //    if (dateSplit.Length != 2)
                //    {
                //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "bad Flower");
                //    }
                //    startDate = DateTime.ParseExact(dateSplit[0], "MM/DD/YYYY", null);
                //    endDate = DateTime.ParseExact(dateSplit[1], "MM/DD/YYYY", null);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e);
                //}
                //var policyToEmp = new PolicyOnEmp()
                //{
                //    PolicyId = currentPolicyOnEmp.PolicyId,
                //    EmployeeId = currentPolicyOnEmp.Id,
                //    PolicyName = currentPolicyOnEmp.PolicyName,
                //    PolicyAmount = currentPolicyOnEmp.Amount,
                //    Emi = currentPolicyOnEmp.Emi,
                //    PolicyStart = startDate,
                //    PolicyEnd = endDate,
                //    CreatedAt = DateTime.Now,
                //    Status = PolOnEmpStatus.ACTIVE
                //};

                //db.Entry(policyToEmp).State = EntityState.Modified;
                //db.PolicyOnEmps.Add(policyToEmp);
                //db.SaveChanges();
                //return RedirectToAction("Index", "PolicyOnEmps");
                db.Entry(policyOnEmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Users, "Id", "Email", policyOnEmp.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", policyOnEmp.PolicyId);
            return View(policyOnEmp);
        }

        // GET: PolicyOnEmps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyOnEmp policyOnEmp = db.PolicyOnEmps.Find(id);
            if (policyOnEmp == null)
            {
                return HttpNotFound();
            }
            return View(policyOnEmp);
        }

        // POST: PolicyOnEmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PolicyOnEmp policyOnEmp = db.PolicyOnEmps.Find(id);
            db.PolicyOnEmps.Remove(policyOnEmp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
