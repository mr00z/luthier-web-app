using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LuthierWebApp.Models;
using LuthierWebApp.Persitence;

namespace LuthierWebApp.Controllers
{
    public class GuitarsController : Controller
    {
        private LuthierDbContext db = new LuthierDbContext();

        // GET: Guitars
        public ActionResult Index()
        {
            return View(db.Guitars.ToList());
        }

        // GET: Guitars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guitar guitar = db.Guitars.Find(id);
            if (guitar == null)
            {
                return HttpNotFound();
            }
            return View(guitar);
        }

        // GET: Guitars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guitars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuitarId,Type,NrOfStrings,Price,CreatedAt")] Guitar guitar)
        {
            guitar.CreatedAt = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                db.Guitars.Add(guitar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guitar);
        }

        // GET: Guitars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guitar guitar = db.Guitars.Find(id);
            if (guitar == null)
            {
                return HttpNotFound();
            }
            return View(guitar);
        }

        // POST: Guitars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuitarId,Type,NrOfStrings,Price,CreatedAt")] Guitar guitar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guitar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guitar);
        }

        // GET: Guitars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guitar guitar = db.Guitars.Find(id);
            if (guitar == null)
            {
                return HttpNotFound();
            }
            return View(guitar);
        }

        // POST: Guitars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guitar guitar = db.Guitars.Find(id);
            db.Guitars.Remove(guitar);
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
