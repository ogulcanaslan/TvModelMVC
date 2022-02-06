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
    public class YayinsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Yayins
        public ActionResult Index()
        {
            var yayin = db.Yayin.Include(y => y.Kanal);
            return View(yayin.ToList());
        }

        // GET: Yayins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yayin yayin = db.Yayin.Find(id);
            if (yayin == null)
            {
                return HttpNotFound();
            }
            return View(yayin);
        }

        // GET: Yayins/Create
        public ActionResult Create()
        {
            ViewBag.KanalKanalId = new SelectList(db.Kanal, "KanalId", "KanalAdi");
            return View();
        }

        // POST: Yayins/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YayinId,YayinAdi,YayinTarihi,YayinReyting,KanalKanalId")] Yayin yayin)
        {
            if (ModelState.IsValid)
            {
                db.Yayin.Add(yayin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KanalKanalId = new SelectList(db.Kanal, "KanalId", "KanalAdi", yayin.KanalKanalId);
            return View(yayin);
        }

        // GET: Yayins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yayin yayin = db.Yayin.Find(id);
            if (yayin == null)
            {
                return HttpNotFound();
            }
            ViewBag.KanalKanalId = new SelectList(db.Kanal, "KanalId", "KanalAdi", yayin.KanalKanalId);
            return View(yayin);
        }

        // POST: Yayins/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YayinId,YayinAdi,YayinTarihi,YayinReyting,KanalKanalId")] Yayin yayin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yayin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KanalKanalId = new SelectList(db.Kanal, "KanalId", "KanalAdi", yayin.KanalKanalId);
            return View(yayin);
        }

        // GET: Yayins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yayin yayin = db.Yayin.Find(id);
            if (yayin == null)
            {
                return HttpNotFound();
            }
            return View(yayin);
        }

        // POST: Yayins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yayin yayin = db.Yayin.Find(id);
            db.Yayin.Remove(yayin);
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
