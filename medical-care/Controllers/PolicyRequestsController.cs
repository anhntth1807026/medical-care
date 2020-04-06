//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using medical_care.Data;
//using medical_care.Models;
//using Microsoft.AspNet.Identity;

//namespace medical_care.Controllers
//{
//    [Authorize(Roles = "admin")]
//    public class PolicyRequestsController : Controller
//    {
//        private MyDbContext db = new MyDbContext();

//        // GET: PolicyRequests
//        public ActionResult Index()
//        {
//            var policyRequests = db.PolicyRequests.Include(p => p.Employee).Include(p => p.Policy);
//            return View(policyRequests.ToList());
//        }

//        // GET: PolicyRequests/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            PolicyRequest policyRequest = db.PolicyRequests.Find(id);
//            if (policyRequest == null)
//            {
//                return HttpNotFound();
//            }
//            return View(policyRequest);
//        }

//        // GET: PolicyRequests/Create
//        public ActionResult Create()
//        {
//            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Firstname");
//            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name");
//            return View();
//        }

//        // POST: PolicyRequests/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "RequestId,RequestDate,Emi,Status,EmployeeId,PolicyId")] PolicyRequest policyRequest)
//        {
//            if (ModelState.IsValid)
//            {
//                db.PolicyRequests.Add(policyRequest);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Firstname", policyRequest.Id);
//            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", policyRequest.PolicyId);
//            return View(policyRequest);
//        }

//        // GET: PolicyRequests/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            PolicyRequest policyRequest = db.PolicyRequests.Find(id);
            
//            if (policyRequest == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Firstname", policyRequest.Id);
//            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", policyRequest.PolicyId);
//            return View(policyRequest);
//        }

//        // POST: PolicyRequests/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(PolicyRequest policyReq, string dateRange)
//        {
//            if (ModelState.IsValid)
//            {
//                PolicyRequest currentPolicyRequest = db.PolicyRequests.Find(policyReq.RequestId);
//                if (currentPolicyRequest == null)
//                {
//                    return new HttpNotFoundResult();
//                }
                
//                //var startDate = DateTime.Now;
//                //var endDate = DateTime.Now.AddYears(1) ;
//                //try
//                //{
//                //    var dateSplit = dateRange.Split('-');
//                //    if (dateSplit.Length != 2)
//                //    {
//                //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "bad Flower");
//                //    }
//                //    startDate = DateTime.ParseExact(dateSplit[0], "MM/DD/YYYY", null);
//                //    endDate = DateTime.ParseExact(dateSplit[1], "MM/DD/YYYY", null);
//                //}
//                //catch (Exception e)
//                //{
//                //    Console.WriteLine(e);
//                //}
//                var confirmRequest = new ConfirmRequest()
//                {
//                    PolicyId = currentPolicyRequest.PolicyId,
//                    EmployeeId = currentPolicyRequest.Id,
//                    PolicyName = currentPolicyRequest.PolicyName,
//                    Amount = currentPolicyRequest.Amount,
//                    Emi = currentPolicyRequest.Emi,
//                    CompanyName = currentPolicyRequest.CompanyName,
//                    ConfirmRequestDate = DateTime.Now,
//                    Status = ConfirmRequestStatus.CONFIRM
//                };
//                Console.WriteLine(confirmRequest);
//                //db.Entry(policyToEmp).State = EntityState.Modified;
//                db.ConfirmRequests.Add(confirmRequest);
//                db.SaveChanges();
//                return RedirectToAction("Index","ConfirmRequests");
//            }
//            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Firstname", policyReq.Id);
//            ViewBag.PolicyId = new SelectList(db.Policies, "PolicyId", "Name", policyReq.PolicyId);
//            return View(policyReq);
//        }

//        // GET: PolicyRequests/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            PolicyRequest policyRequest = db.PolicyRequests.Find(id);
//            if (policyRequest == null)
//            {
//                return HttpNotFound();
//            }
//            return View(policyRequest);
//        }

//        // POST: PolicyRequests/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            PolicyRequest policyRequest = db.PolicyRequests.Find(id);
//            db.PolicyRequests.Remove(policyRequest);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
