using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FPFI.DAL;
using FPFI.Models;

namespace FPFI.Controllers
{
    public class MealPlansController : Controller
    {
        private FPFIContext db = new FPFIContext();

        // GET: MealPlans
        public ActionResult Index()
        {
            var mealPlans = db.MealPlans.Include(m => m.Account);
            return View(mealPlans.ToList());
        }

        // GET: MealPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealPlan mealPlan = db.MealPlans.Find(id);
            if (mealPlan == null)
            {
                return HttpNotFound();
            }
            return View(mealPlan);
        }

        // GET: MealPlans/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Login");
            return View();
        }

        // POST: MealPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MealPlansID,AccountID,MealID,MeakDay,Section")] MealPlan mealPlan)
        {
            if (ModelState.IsValid)
            {
                db.MealPlans.Add(mealPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Login", mealPlan.AccountID);
            return View(mealPlan);
        }

        // GET: MealPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealPlan mealPlan = db.MealPlans.Find(id);
            if (mealPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Login", mealPlan.AccountID);
            return View(mealPlan);
        }

        // POST: MealPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MealPlansID,AccountID,MealID,MeakDay,Section")] MealPlan mealPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mealPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "Login", mealPlan.AccountID);
            return View(mealPlan);
        }

        // GET: MealPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealPlan mealPlan = db.MealPlans.Find(id);
            if (mealPlan == null)
            {
                return HttpNotFound();
            }
            return View(mealPlan);
        }

        // POST: MealPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MealPlan mealPlan = db.MealPlans.Find(id);
            db.MealPlans.Remove(mealPlan);
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
