using FPFI.DAL;
using FPFI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace FPFI.Controllers
{
    public class IngredientController : Controller
    {
        private FPFIContext db = new FPFIContext();

        // GET: Ingredient
        public ActionResult Index()
        {
            return View(db.Ingredients.ToList());
        }

        // GET: Ingredient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ingredient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredient/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name, Type, Nutriscore, Endurance, Allergen, UnitID")] Ingredient ingredient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Ingredients.Add(ingredient);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.UnitID = new SelectList(db.Units, "UnitID", "Name", ingredient.UnitID);
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(ingredient);
        }

        // GET: Ingredient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ingredient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingredient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ingredient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
