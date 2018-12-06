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
    public class Genre_filmController : Controller
    {
        private QLRCP db = new QLRCP();

        // GET: Admin/Genre_film
        public ActionResult Index()
        {
            return View();
        }

     
        
        // GET: Admin/Genre_film/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: Admin/Genre_film/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre_film genre_film = db.Genre_film.Find(id);
            if (genre_film == null)
            {
                return HttpNotFound();
            }
            return View(genre_film);
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
