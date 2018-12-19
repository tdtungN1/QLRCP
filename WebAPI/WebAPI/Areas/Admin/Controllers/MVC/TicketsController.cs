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
    public class TicketsController : Controller
    {
        private QLRCP db = new QLRCP();

        private const string CartSession = "CartSession";
        // GET: Admin/Tickets
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<Ticket>();
            if (cart != null)
            {
                list = (List<Ticket>)cart;
            }
            return View(list);
        }

        public ActionResult OrderTicket()
        {
            return View();
        }

        // GET: Admin/Tickets/AddCart/?showTimeID=1&chairID=1
        public ActionResult AddCart(int showTimeID, int chairID,Boolean specialDay)
        {
            var cartSession = Session[CartSession];
            if (cartSession == null)
            {
                var list = new List<Ticket>();
                cartSession = list;
            }
            var carts = (List<Ticket>)cartSession;
            var ticket = new Ticket();
            ShowTime showTime = db.ShowTimes.Find(showTimeID);
            Chair chair = db.Chairs.Find(chairID);
            ticket.ShowTimeID = showTimeID;
            ticket.ChairID = chairID;
            ticket.Chair = chair;
            ticket.ShowTime = showTime;
            //1: 2D
            //2: 3D
            //3: 4D

            //1: Ghế Thường
            //2: Ghế Vip
            //3: Ghế ĐÔi
            if (chair.Room.GenreRoomID==1)
            {
                ticket.Price = 45000;
            }
            else if (chair.Room.GenreRoomID == 2)
            {
                ticket.Price = 60000;
                
            }
            if (chair.Room.GenreRoomID == 3)
            {
                ticket.Price += 90000;
            }
            else
            {
                if (chair.GenreChairID == 2)
                {
                    ticket.Price += 10000;
                }
                else if (chair.GenreChairID == 3)
                {
                    ticket.Price += 15000;
                }
            }
            if (specialDay == true)
            {
                ticket.Price += 10000;
            }
            carts.Add(ticket);
            cartSession = carts;
            return RedirectToAction("/Index");
        }
        // GET: Admin/Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Admin/Tickets/Create
        public ActionResult Create()
        {
            ViewBag.ChairID = new SelectList(db.Chairs, "ChairID", "ChairName");
            ViewBag.ShowTimeID = new SelectList(db.ShowTimes, "ShowTimeID", "ShowTimeID");
            return View();
        }

        // POST: Admin/Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,ShowTimeID,ChairID,Price")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChairID = new SelectList(db.Chairs, "ChairID", "ChairName", ticket.ChairID);
            ViewBag.ShowTimeID = new SelectList(db.ShowTimes, "ShowTimeID", "ShowTimeID", ticket.ShowTimeID);
            return View(ticket);
        }

        // GET: Admin/Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChairID = new SelectList(db.Chairs, "ChairID", "ChairName", ticket.ChairID);
            ViewBag.ShowTimeID = new SelectList(db.ShowTimes, "ShowTimeID", "ShowTimeID", ticket.ShowTimeID);
            return View(ticket);
        }

        // POST: Admin/Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,ShowTimeID,ChairID,Price")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChairID = new SelectList(db.Chairs, "ChairID", "ChairName", ticket.ChairID);
            ViewBag.ShowTimeID = new SelectList(db.ShowTimes, "ShowTimeID", "ShowTimeID", ticket.ShowTimeID);
            return View(ticket);
        }

        // GET: Admin/Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Admin/Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
