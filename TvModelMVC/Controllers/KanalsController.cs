using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TvModelMVC.Models;

namespace TvModelMVC.Controllers
{
    public class KanalsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Kanals
        public ActionResult Index()
        {
            return View(db.Kanal.ToList());
        }

        // GET: Kanals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kanal kanal = db.Kanal.Find(id);
            if (kanal == null)
            {
                return HttpNotFound();
            }
            return View(kanal);
        }

        // GET: Kanals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kanals/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KanalId,KanalAdi,KanalCiro,KanalAdres,KanalReyting")] Kanal kanal)
        {
            if (ModelState.IsValid)
            {
                db.Kanal.Add(kanal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kanal);
        }

        // GET: Kanals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kanal kanal = db.Kanal.Find(id);
            if (kanal == null)
            {
                return HttpNotFound();
            }
            return View(kanal);
        }

        // POST: Kanals/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KanalId,KanalAdi,KanalCiro,KanalAdres,KanalReyting")] Kanal kanal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kanal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kanal);
        }

        // GET: Kanals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kanal kanal = db.Kanal.Find(id);
            if (kanal == null)
            {
                return HttpNotFound();
            }
            return View(kanal);
        }

        // POST: Kanals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kanal kanal = db.Kanal.Find(id);
            db.Kanal.Remove(kanal);
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
