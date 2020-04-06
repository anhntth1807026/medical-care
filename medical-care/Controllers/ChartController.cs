using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using medical_care.Data;
using medical_care.Models;

namespace medical_care.Controllers
{
    public class ChartController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetChartData(string start, string end)
        {
            var startTime = DateTime.Now;
            startTime = startTime.AddYears(-1);
            try
            {
                startTime = DateTime.Parse(start);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0, 0);

            var endTime = DateTime.Now;
            try
            {
                endTime = DateTime.Parse(end);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, 23, 59, 59, 0);

            var data = db.PolicyOnEmps.Where(s => s.Status != PolOnEmpStatus.DEACTIVE && (s.CreatedAt >= startTime && s.CreatedAt <= endTime))
                .GroupBy(
                    s => new
                    {
                        Year = s.CreatedAt.Year,
                        Month = s.CreatedAt.Month,
                        Day = s.CreatedAt.Day
                    }
                ).Select(s => new
                {
                    Date = s.FirstOrDefault().CreatedAt,
                    Count = s.Count()
                }).OrderBy(s => s.Date).ToList();
            return new JsonResult()
            {
                Data = data.Select(s => new
                {
                    Date = s.Date.ToString("MM/dd/yyyy"),
                    Count = s.Count
                }),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult GetData()
        {
            int bhyt = db.PolicyOnEmps.Where(x => x.PolicyName == "Bảo hiểm y tế").Count();
            int bhsk = db.PolicyOnEmps.Where(x => x.PolicyName == "Bảo hiểm sức khỏe").Count();
            int bhnt = db.PolicyOnEmps.Where(x => x.PolicyName == "Bảo hiểm nhân thọ").Count();
            int bhpnt = db.PolicyOnEmps.Where(x => x.PolicyName == "Bảo hiểm phi nhân thọ").Count();
            Insurance obj = new Insurance();
            obj.Bhyt = bhyt;
            obj.Bhsk = bhsk;
            obj.Bhnt = bhnt;
            obj.Bhpnt = bhpnt;
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public class Insurance
        {
            public int Bhyt { get; set; }
            public int Bhsk { get; set; }
            public int Bhnt { get; set; }
            public int Bhpnt { get; set; }
        }


    }
}