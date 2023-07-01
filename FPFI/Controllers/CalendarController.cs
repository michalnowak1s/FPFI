using FPFI.DAL;
using FPFI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPFI.Controllers
{
    public class CalendarController : Controller
    {
        private FPFIContext db = new FPFIContext();
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEvents()
        {
           
                var events = db.MealPlans.ToList();
                return new JsonResult
                {
                    Data = events,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
           
        }
        [HttpGet]
        public ActionResult AddEvent()
        {
            ViewBag.MealID = new SelectList(db.Meal, "MealID", "name");
            return View();
        }

        [HttpPost]
        public ActionResult AddEvent([Bind(Include = "MealPlansID,MealID,StartData,EndData,Title,Description")] MealPlan plan)
        {
            if (ModelState.IsValid)
            {
                db.MealPlans.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MealID = new SelectList(db.Meal, "MealID", "Name", plan.MealID);
            return View(plan);
        }
        /*[HttpPost]
        public JsonResult addEvent(MealPlan m )
        {
            var status = 0;
            
                if(m.MealPlansID > 0) 
                {
                    var v = db.MealPlans.Where(a => a.MealPlansID == m.MealPlansID).FirstOrDefault();
                    if (m.MealPlansID != 0)
                    {
                        v.Title = m.Title; 
                        v.StartData = m.StartData;
                        v.EndData = m.EndData;
                        v.Description = m.Description;
                    }

                }   
                else
                {
                    db.MealPlans.Add(m);
                }
                db.SaveChanges();
                status = 1;
            
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var status = 0;
            using (var db = new FPFIContext()) { 
                var v = db.MealPlans.Where(a=> a.MealPlansID==id).FirstOrDefault();
                if (v != null)
                {
                    db.MealPlans.Remove(v);
                    db.SaveChanges();
                    status = 1;
                }
            }

            return new JsonResult { Data = new {status = status} };
        }*/
    }
}
