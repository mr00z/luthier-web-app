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
    public class MessagesController : Controller
    {
        private LuthierDbContext db = new LuthierDbContext();

        // GET: Messages
        public ActionResult Index()
        {
            var id = Session["customerID"];
            var messages = db.Messages.Include(m => m.Customer).Where(m=>m.CustomerId==(int)id);
            return View(messages.ToList());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            //ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            if (Session["user"] != null)
                return View();
            else
                return RedirectToAction("Authorize", "Home");
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageId,Subject,Value,SentAt,CustomerId")] Message message)
        {
            if (ModelState.IsValid)
            {
                var id = Session["customerID"];
                var cust = (from c in db.Customers
                            where c.CustomerId == (int)id
                            select c).FirstOrDefault();
                message.Customer = cust;
                message.CustomerId = cust.CustomerId;
                message.SentAt = DateTime.Now;
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", message.CustomerId);
            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", message.CustomerId);
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageId,Subject,Value,SentAt,CustomerId")] Message message)
        {
            if (ModelState.IsValid)
            {
                var m = (from ms in db.Messages
                         where ms.MessageId == message.MessageId
                         select ms).FirstOrDefault();
                m.Subject = message.Subject;
                m.Value = message.Value;
                //db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", message.CustomerId);
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
