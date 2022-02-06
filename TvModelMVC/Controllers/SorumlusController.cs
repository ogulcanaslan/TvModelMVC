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
    public class SorumlusController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Sorumlus
        public ActionResult Index()
        {
            var sorumlu = db.Sorumlu.Include(s => s.Yayin);
            return View(sorumlu.ToList());
        }

        // GET: Sorumlus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorumlu sorumlu = db.Sorumlu.Find(id);
            if (sorumlu == null)
            {
                return HttpNotFound();
            }
            return View(sorumlu);
        }

        // GET: Sorumlus/Create
        public ActionResult Create()
        {
            ViewBag.YayinYayinId = new SelectList(db.Yayin, "YayinId", "YayinAdi");
            return View();
        }

        // POST: Sorumlus/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SorumluId,SorumluIsim,SorumluGorevi,SorumluMaas,YayinYayinId")] Sorumlu sorumlu)
        {
            if (ModelState.IsValid)
            {
                db.Sorumlu.Add(sorumlu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.YayinYayinId = new SelectList(db.Yayin, "YayinId", "YayinAdi", sorumlu.YayinYayinId);
            return View(sorumlu);
        }

        // GET: Sorumlus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorumlu sorumlu = db.Sorumlu.Find(id);
            if (sorumlu == null)
            {
                return HttpNotFound();
            }
            ViewBag.YayinYayinId = new SelectList(db.Yayin, "YayinId", "YayinAdi", sorumlu.YayinYayinId);
            return View(sorumlu);
        }

        // POST: Sorumlus/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SorumluId,SorumluIsim,SorumluGorevi,SorumluMaas,YayinYayinId")] Sorumlu sorumlu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sorumlu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YayinYayinId = new SelectList(db.Yayin, "YayinId", "YayinAdi", sorumlu.YayinYayinId);
            return View(sorumlu);
        }

        // GET: Sorumlus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorumlu sorumlu = db.Sorumlu.Find(id);
            if (sorumlu == null)
            {
                return HttpNotFound();
            }
            return View(sorumlu);
        }

        // POST: Sorumlus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sorumlu sorumlu = db.Sorumlu.Find(id);
            db.Sorumlu.Remove(sorumlu);
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
