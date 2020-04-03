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
    public class ConfirmRequestsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: ConfirmRequests
        public ActionResult Index()
        {
            var confirmRequests = db.ConfirmRequests.Include(c => c.Employee).Include(c => c.Policy);
            return View(confirmRequests.ToList());
        }

        // GET: ConfirmRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmRequest confirmRequest = db.ConfirmRequests.Find(id);
            if (confirmRequest == null)
            {
                return HttpNotFound();
            }
            return View(confirmRequest);
        }

        // GET: ConfirmRequests/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Email");
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name");
            return View();
        }

        // POST: ConfirmRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ConfirmRequestDate,Amount,Emi,CompanyName,PolicyName,Status,EmployeeId,PolicyId")] ConfirmRequest confirmRequest)
        {
            if (ModelState.IsValid)
            {
                db.ConfirmRequests.Add(confirmRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Email", confirmRequest.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", confirmRequest.PolicyId);
            return View(confirmRequest);
        }

        // GET: ConfirmRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmRequest confirmRequest = db.ConfirmRequests.Find(id);
            if (confirmRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Email", confirmRequest.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", confirmRequest.PolicyId);
            return View(confirmRequest);
        }

        // POST: ConfirmRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConfirmRequest confirmRequest, string dateRange)
        {
            if (ModelState.IsValid)
            {
                ConfirmRequest currentPolicyRequest = db.ConfirmRequests.Find(confirmRequest.Id);
                if (currentPolicyRequest == null)
                {
                    return new HttpNotFoundResult();
                }

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
                var policyToEmp = new PolicyOnEmp()
                {
                    PolicyId = currentPolicyRequest.PolicyId,
                    EmployeeId = currentPolicyRequest.EmployeeId,
                    PolicyName = currentPolicyRequest.PolicyName,
                    PolicyAmount = currentPolicyRequest.Amount,
                    Emi = currentPolicyRequest.Emi,
                    PolicyStart = startDate,
                    PolicyEnd = endDate,
                    CreatedAt = DateTime.Now,
                    Status = PolOnEmpStatus.ACTIVE
                };
                Console.WriteLine(policyToEmp);
                //db.Entry(policyToEmp).State = EntityState.Modified;
                db.PolicyOnEmps.Add(policyToEmp);
                db.SaveChanges();
                return RedirectToAction("Index", "PolicyOnEmps");
                //db.Entry(policyOnEmp).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Email", confirmRequest.EmployeeId);
            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", confirmRequest.PolicyId);
            return View(confirmRequest);
        }

        // GET: ConfirmRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmRequest confirmRequest = db.ConfirmRequests.Find(id);
            if (confirmRequest == null)
            {
                return HttpNotFound();
            }
            return View(confirmRequest);
        }

        // POST: ConfirmRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConfirmRequest confirmRequest = db.ConfirmRequests.Find(id);
            db.ConfirmRequests.Remove(confirmRequest);
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
