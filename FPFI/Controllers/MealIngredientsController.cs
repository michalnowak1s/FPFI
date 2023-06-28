using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using FPFI.DAL;
using FPFI.Models;

namespace FPFI.Controllers
{
    public class MealIngredientsController : Controller
    {
        private FPFIContext db = new FPFIContext();

        // GET: MealIngredients
        public ActionResult Index()
        {
            var mealIngredients = db.MealIngredients.Include(m => m.Ingredient).Include(m => m.Meal);
            return View(mealIngredients.ToList());
        }

        // GET: MealIngredients/Details/5
        public ActionResult Details(int? id)
        {
            return RedirectToAction("Details", "MealIngredients", new { id = id });
        }
        public class MealIngredientsWithUnit
        {
            public int Meal { get; set; }
            public string Ingredient { get; set; }
            public int Quantity { get; set; }
            public string Unit { get; set; }
            // Dodaj inne wymagane kolumny
        }
        public ActionResult MealIngredients(int? id)
        {
            var query = from MealIngredient in db.MealIngredients
                        join Ingredient in db.Ingredients on MealIngredient.IngredientID equals Ingredient.IngredientID
                        join Unit in db.Units on Ingredient.UnitID equals Unit.UnitID
                        select new MealIngredientsWithUnit
                        {
                            Meal = MealIngredient.MealID,
                            Ingredient = Ingredient.Name,
                            Unit = Unit.Name,
                            Quantity = MealIngredient.Quantity
                        };

            var filterQuery = query.Where(c => c.Meal == id);

            List<MealIngredientsWithUnit> resultList = filterQuery.ToList();


            return View(resultList);
        }

        [HttpPost]
        public ActionResult CreateToMeal(MealIngredient model)
        {
            if (ModelState.IsValid)
            {
                // Przypisanie wartości ID klucza obcego z formularza
                model.MealID = Convert.ToInt32(Request.Form["MealID"]);

                db.MealIngredients.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", new { MealID = model.MealID });
            }

            return View(model);
        }

            // GET: MealIngredients/Create
            public ActionResult Create()
        {
            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "Name");
            ViewBag.MealID = new SelectList(db.Meal, "MealID", "Name");
            return View();
        }

        // POST: MealIngredients/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MealsIngredientsID,IngredientID,MealID,Quantity")] MealIngredient mealIngredient)
        {
            if (ModelState.IsValid)
            {
                db.MealIngredients.Add(mealIngredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "Name", mealIngredient.IngredientID);
            ViewBag.MealID = new SelectList(db.Meal, "MealID", "Name", mealIngredient.MealID);
            return View(mealIngredient);
        }

        // GET: MealIngredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealIngredient mealIngredient = db.MealIngredients.Find(id);
            if (mealIngredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "Name", mealIngredient.IngredientID);
            ViewBag.MealID = new SelectList(db.Meal, "MealID", "Name", mealIngredient.MealID);
            return View(mealIngredient);
        }

        // POST: MealIngredients/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MealsIngredientsID,IngredientID,MealID,Quantity")] MealIngredient mealIngredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mealIngredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "Name", mealIngredient.IngredientID);
            ViewBag.MealID = new SelectList(db.Meal, "MealID", "Name", mealIngredient.MealID);
            return View(mealIngredient);
        }

        // GET: MealIngredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealIngredient mealIngredient = db.MealIngredients.Find(id);
            if (mealIngredient == null)
            {
                return HttpNotFound();
            }
            return View(mealIngredient);
        }

        // POST: MealIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MealIngredient mealIngredient = db.MealIngredients.Find(id);
            db.MealIngredients.Remove(mealIngredient);
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
