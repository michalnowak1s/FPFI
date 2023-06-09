﻿using FPFI.DAL;
using FPFI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace FPFI.Controllers
{
    public class RegistrationController : Controller
    {
        private FPFIContext db = new FPFIContext();
        // GET: Registration
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());

        }

        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Login, Password, Email")] Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Accounts.Add(account);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(account);
        }

        // GET: Registration/Edit/5
        public ActionResult Edit(int id=0)
        {
            return View(db.Accounts.Find(id));
        }

        // POST: Registration/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var accountToUpdate = db.Accounts.Find(id);
            if (TryUpdateModel(accountToUpdate, "",
               new string[] { "Login", "Password", "Email" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            //PopulateDepartmentsDropDownList(courseToUpdate.DepartmentID);
            return View(accountToUpdate);
        }

        // GET: Registration/Delete/5
        public ActionResult Delete(int id)
        {

            return View(db.Accounts.Find(id));
        }


        // POST: Registration/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Account account)
        {
            try
            {
                account = db.Accounts.Find(id);
                db.Accounts.Remove(account);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
