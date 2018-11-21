using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Areas.Admin.Controllers.MVC
{
    public class Genre_chairController : Controller
    {
        private QLRCP db = new QLRCP();

        // GET: Admin/Genre_chair
        public ActionResult Index()
        {
            return View(db.Genre_chair.ToList());
        }

        // GET: Admin/Genre_chair/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre_chair genre_chair = db.Genre_chair.Find(id);
            if (genre_chair == null)
            {
                return HttpNotFound();
            }
            return View(genre_chair);
        }

        // GET: Admin/Genre_chair/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Genre_chair/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreChairID,GenreChairName")] Genre_chair genre_chair)
        {
            if (ModelState.IsValid)
            {
                db.Genre_chair.Add(genre_chair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre_chair);
        }

        // GET: Admin/Genre_chair/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre_chair genre_chair = db.Genre_chair.Find(id);
            if (genre_chair == null)
            {
                return HttpNotFound();
            }
            return View(genre_chair);
        }

        // POST: Admin/Genre_chair/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreChairID,GenreChairName")] Genre_chair genre_chair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre_chair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre_chair);
        }

        // GET: Admin/Genre_chair/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre_chair genre_chair = db.Genre_chair.Find(id);
            if (genre_chair == null)
            {
                return HttpNotFound();
            }
            return View(genre_chair);
        }

        // POST: Admin/Genre_chair/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre_chair genre_chair = db.Genre_chair.Find(id);
            db.Genre_chair.Remove(genre_chair);
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
