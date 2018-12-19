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
    public class ShowTimesController : Controller
    {
        private QLRCP db = new QLRCP();

        // GET: Admin/ShowTimes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/ShowTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = db.ShowTimes.Find(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            return View(showTime);
        }

        // GET: Admin/ShowTimes/Create
        public ActionResult Create()
        {
            ViewBag.FilmID = new SelectList(db.Films, "FilmID", "FilmName");
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomName");
            return View();
        }

        // POST: Admin/ShowTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowTimeID,FilmID,RoomID,StartTime")] ShowTime showTime)
        {
            if (ModelState.IsValid)
            {
                db.ShowTimes.Add(showTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmID = new SelectList(db.Films, "FilmID", "FilmName", showTime.FilmID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomName", showTime.RoomID);
            return View(showTime);
        }

        // GET: Admin/ShowTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = db.ShowTimes.Find(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmID = new SelectList(db.Films, "FilmID", "FilmName", showTime.FilmID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomName", showTime.RoomID);
            return View(showTime);
        }

        // POST: Admin/ShowTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowTimeID,FilmID,RoomID,StartTime")] ShowTime showTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmID = new SelectList(db.Films, "FilmID", "FilmName", showTime.FilmID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomName", showTime.RoomID);
            return View(showTime);
        }

        // GET: Admin/ShowTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTime showTime = db.ShowTimes.Find(id);
            if (showTime == null)
            {
                return HttpNotFound();
            }
            return View(showTime);
        }

        // POST: Admin/ShowTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShowTime showTime = db.ShowTimes.Find(id);
            db.ShowTimes.Remove(showTime);
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
