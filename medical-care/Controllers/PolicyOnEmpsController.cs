using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using medical_care.Data;
using medical_care.Models;
using Microsoft.AspNet.Identity;

namespace medical_care.Controllers
{
    [Authorize(Roles = "admin")]
    public class PolicyOnEmpsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: PolicyOnEmps
        public ActionResult Index(string listcontracts, DateTime? startDate, DateTime? endDate)
        {
            ViewBag.listcontracts = new List<SelectListItem>()
            {

                new SelectListItem() { Text="All", Value= "4" },
                new SelectListItem() { Text="Confirm", Value= "3"},

                new SelectListItem() { Text="Pending", Value= "2" },
                new SelectListItem() { Text="Deactive", Value= "0"},
                new SelectListItem() { Text="Active", Value= "1" },

            };
            var policyOnEmps = db.PolicyOnEmps.Include(p => p.Employee).Include(p => p.Policy);
            if (startDate != null && endDate != null)
            {
                policyOnEmps = policyOnEmps.Where(x => x.CreatedAt >= startDate && x.CreatedAt <= endDate);
            }
            switch (listcontracts)
            {
                case "1":
                    policyOnEmps = policyOnEmps.Where(x => x.Status == PolOnEmpStatus.ACTIVE);
                    break;
                case "2":
                    policyOnEmps = policyOnEmps.Where(x => x.Status == PolOnEmpStatus.PENDING);
                    break;
                case "3":
                    policyOnEmps = policyOnEmps.Where(x => x.Status == PolOnEmpStatus.CONFIRM);
                    break;
                case "0":
                    policyOnEmps = policyOnEmps.Where(x => x.Status == PolOnEmpStatus.DEACTIVE);
                    break;
                default:
                    break;
            }
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
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "PolicyName,CompanyName,HospitalName,PolicyAmount,PolicyStart,PolicyEnd,CreatedAt,UpdatedAt,Status")] PolicyOnEmp policyOnEmp)
        //[Bind(Include = "PolicyName,CompanyName,HospitalName,PolicyAmount,PolicyStart,PolicyEnd,UpdatedAt,Status")]
        {
            if (ModelState.IsValid)
            {

                //var currentPolicyOnEmp = db.PolicyOnEmps.Find(policyOnEmp.Id);
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

                //policyOnEmp = new PolicyOnEmp()
                //{
                //    PolicyId = currentPolicyOnEmp.PolicyId,
                //    EmployeeId = (HttpContext.User.Identity.GetUserId()),
                //    RequestDate = DateTime.Now,
                //    PolicyDuration = currentPolicyOnEmp.PolicyDuration,
                //    PolicyAmount = currentPolicyOnEmp.PolicyAmount,
                //    PolicyName = currentPolicyOnEmp.PolicyName,
                //    PolicyStart = startDate,
                //    PolicyEnd = endDate,
                //    CompanyName = currentPolicyOnEmp.Company.Name,
                //    HospitalName = currentPolicyOnEmp.Hospital.Name,
                //    UpdatedAt = DateTime.Now.ToString(),
                //    Status = PolOnEmpStatus.PENDING
                //};

                //db.Entry(policyToEmp).State = EntityState.Modified;
                //db.PolicyOnEmps.AddOrUpdate(policyEmp);
                //db.SaveChanges();
                //return RedirectToAction("Index", "PolicyOnEmps");

                db.Entry(policyOnEmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "PolicyOnEmps");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStatus(PolOnEmpStatus action, int[] selectedIDs)
        {
            foreach (int IDs in selectedIDs)
            {
                PolicyOnEmp policyOnEmp = db.PolicyOnEmps.Find(IDs);
                db.PolicyOnEmps.Attach(policyOnEmp);
                policyOnEmp.Status = action;
            }
            db.SaveChanges();
            return Json(selectedIDs, JsonRequestBehavior.AllowGet);
        }


    }
}
