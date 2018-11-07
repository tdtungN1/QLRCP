using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Areas.Admin.Controllers
{
    public class Projection_roomController : Controller
    {
        private QLRapChieuPhimEntities db = new QLRapChieuPhimEntities();

        // GET: Admin/Projection_room
        public ActionResult Index()
        {
            var projection_room = db.Projection_room.Include(p => p.Genre_room);
            return View(projection_room.ToList());
        }

        // GET: Admin/Projection_room/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection_room projection_room = db.Projection_room.Find(id);
            if (projection_room == null)
            {
                return HttpNotFound();
            }
            return View(projection_room);
        }

        // GET: Admin/Projection_room/Create
        public ActionResult Create()
        {
            ViewBag.GenreRoomID = new SelectList(db.Genre_room, "GenreRoomID", "GenreRoomName");
            return View();
        }

        // POST: Admin/Projection_room/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomID,RoomName,GenreRoomID,StatusRoom")] Projection_room projection_room)
        {
            if (ModelState.IsValid)
            {
                db.Projection_room.Add(projection_room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreRoomID = new SelectList(db.Genre_room, "GenreRoomID", "GenreRoomName", projection_room.GenreRoomID);
            return View(projection_room);
        }

        // GET: Admin/Projection_room/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection_room projection_room = db.Projection_room.Find(id);
            if (projection_room == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreRoomID = new SelectList(db.Genre_room, "GenreRoomID", "GenreRoomName", projection_room.GenreRoomID);
            return View(projection_room);
        }

        // POST: Admin/Projection_room/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomID,RoomName,GenreRoomID,StatusRoom")] Projection_room projection_room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projection_room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreRoomID = new SelectList(db.Genre_room, "GenreRoomID", "GenreRoomName", projection_room.GenreRoomID);
            return View(projection_room);
        }

        // GET: Admin/Projection_room/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projection_room projection_room = db.Projection_room.Find(id);
            if (projection_room == null)
            {
                return HttpNotFound();
            }
            return View(projection_room);
        }

        // POST: Admin/Projection_room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Projection_room projection_room = db.Projection_room.Find(id);
            db.Projection_room.Remove(projection_room);
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
