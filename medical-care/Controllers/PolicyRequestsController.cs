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
    public class PolicyRequestsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: PolicyRequests
        public ActionResult Index()
        {
            var policyRequests = db.PolicyRequests.Include(p => p.Employee).Include(p => p.Policy);
            return View(policyRequests.ToList());
        }

        // GET: PolicyRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyRequest policyRequest = db.PolicyRequests.Find(id);
            if (policyRequest == null)
            {
                return HttpNotFound();
            }
            return View(policyRequest);
        }

        // GET: PolicyRequests/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Firstname");
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name");
            return View();
        }

        // POST: PolicyRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId,RequestDate,Emi,Status,EmployeeId,PolicyId")] PolicyRequest policyRequest)
        {
            if (ModelState.IsValid)
            {
                db.PolicyRequests.Add(policyRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Firstname", policyRequest.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", policyRequest.PolicyId);
            return View(policyRequest);
        }

        // GET: PolicyRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyRequest policyRequest = db.PolicyRequests.Find(id);
            if (policyRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Firstname", policyRequest.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", policyRequest.PolicyId);
            return View(policyRequest);
        }

        // POST: PolicyRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestId,RequestDate,Emi,Status,EmployeeId,PolicyId")] PolicyRequest policyRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policyRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Firstname", policyRequest.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", policyRequest.PolicyId);
            return View(policyRequest);
        }

        // GET: PolicyRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PolicyRequest policyRequest = db.PolicyRequests.Find(id);
            if (policyRequest == null)
            {
                return HttpNotFound();
            }
            return View(policyRequest);
        }

        // POST: PolicyRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PolicyRequest policyRequest = db.PolicyRequests.Find(id);
            db.PolicyRequests.Remove(policyRequest);
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
