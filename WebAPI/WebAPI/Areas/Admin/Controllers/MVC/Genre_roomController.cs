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
    public class Genre_roomController : Controller
    {
        private QLRCP db = new QLRCP();

        // GET: Admin/Genre_room
        public ActionResult Index()
        {
            return View(db.Genre_room.ToList());
        }

        // GET: Admin/Genre_room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre_room genre_room = db.Genre_room.Find(id);
            if (genre_room == null)
            {
                return HttpNotFound();
            }
            return View(genre_room);
        }

        // GET: Admin/Genre_room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Genre_room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreRoomID,GenreRoomName")] Genre_room genre_room)
        {
            if (ModelState.IsValid)
            {
                db.Genre_room.Add(genre_room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre_room);
        }

        // GET: Admin/Genre_room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre_room genre_room = db.Genre_room.Find(id);
            if (genre_room == null)
            {
                return HttpNotFound();
            }
            return View(genre_room);
        }

        // POST: Admin/Genre_room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreRoomID,GenreRoomName")] Genre_room genre_room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre_room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre_room);
        }

        // GET: Admin/Genre_room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre_room genre_room = db.Genre_room.Find(id);
            if (genre_room == null)
            {
                return HttpNotFound();
            }
            return View(genre_room);
        }

        // POST: Admin/Genre_room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre_room genre_room = db.Genre_room.Find(id);
            db.Genre_room.Remove(genre_room);
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
