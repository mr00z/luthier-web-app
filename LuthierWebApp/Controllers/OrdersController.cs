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
    public class OrdersController : Controller
    {
        private LuthierDbContext db = new LuthierDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var custId = (int)Session["customerID"];
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Guitar).Include(o => o.Luthier).Where(o=>o.CustomerId==custId);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            if (Session["user"] == null)
                return RedirectToAction("Authorize", "Home");

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            ViewBag.GuitarId = new SelectList(db.Guitars, "GuitarId", "Type");
            ViewBag.LuthierId = new SelectList(db.Luthiers, "LuthierId", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,OrderDate,CustomerId,LuthierId,GuitarId")] Order order)
        {
            if (ModelState.IsValid)
            {
                var custID = (int)Session["customerID"];
                var cust = db.Customers.Where(c => c.CustomerId == custID).FirstOrDefault();
                order.CustomerId = custID;
                order.Customer = cust;
                order.OrderDate = DateTime.Now;

                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", order.CustomerId);
            ViewBag.GuitarId = new SelectList(db.Guitars, "GuitarId", "Type", order.GuitarId);
            ViewBag.LuthierId = new SelectList(db.Luthiers, "LuthierId", "Name", order.LuthierId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", order.CustomerId);
            ViewBag.GuitarId = new SelectList(db.Guitars, "GuitarId", "Type", order.GuitarId);
            ViewBag.LuthierId = new SelectList(db.Luthiers, "LuthierId", "Name", order.LuthierId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,OrderDate,CustomerId,LuthierId,GuitarId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", order.CustomerId);
            ViewBag.GuitarId = new SelectList(db.Guitars, "GuitarId", "Type", order.GuitarId);
            ViewBag.LuthierId = new SelectList(db.Luthiers, "LuthierId", "Name", order.LuthierId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
