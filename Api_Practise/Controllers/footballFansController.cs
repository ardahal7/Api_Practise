using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Api_Practise.Models;

namespace Api_Practise.Controllers
{
    public class footballFansController : Controller
    {
        private Api_PractiseContext db = new Api_PractiseContext();

        // GET: footballFans
        public ActionResult Index()
        {
            var footballFans = db.footballFans.Include(f => f.Footballers);
            return View(footballFans.ToList());
        }

        // GET: footballFans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            footballFans footballFans = db.footballFans.Find(id);
            if (footballFans == null)
            {
                return HttpNotFound();
            }
            return View(footballFans);
        }

        // GET: footballFans/Create
        public ActionResult Create()
        {
            ViewBag.FootballersID = new SelectList(db.Footballers, "FootballersID", "club");
            return View();
        }

        // POST: footballFans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FootballersID,name")] footballFans footballFans)
        {
            if (ModelState.IsValid)
            {
                db.footballFans.Add(footballFans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FootballersID = new SelectList(db.Footballers, "FootballersID", "club", footballFans.FootballersID);
            return View(footballFans);
        }

        // GET: footballFans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            footballFans footballFans = db.footballFans.Find(id);
            if (footballFans == null)
            {
                return HttpNotFound();
            }
            ViewBag.FootballersID = new SelectList(db.Footballers, "FootballersID", "club", footballFans.FootballersID);
            return View(footballFans);
        }

        // POST: footballFans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FootballersID,name")] footballFans footballFans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footballFans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FootballersID = new SelectList(db.Footballers, "FootballersID", "club", footballFans.FootballersID);
            return View(footballFans);
        }

        // GET: footballFans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            footballFans footballFans = db.footballFans.Find(id);
            if (footballFans == null)
            {
                return HttpNotFound();
            }
            return View(footballFans);
        }

        // POST: footballFans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            footballFans footballFans = db.footballFans.Find(id);
            db.footballFans.Remove(footballFans);
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
