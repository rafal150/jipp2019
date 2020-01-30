using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Konwerter;

namespace Konwerter.Web.Controllers
{
    public class KalkulatorsController : Controller
    {
        private Model db = new Model();

        // GET: Kalkulators
        public ActionResult Index()
        {
            return View(db.Kalkulator.ToList());
        }

        // GET: Kalkulators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalkulator kalkulator = db.Kalkulator.Find(id);
            if (kalkulator == null)
            {
                return HttpNotFound();
            }
            return View(kalkulator);
        }

        // GET: Kalkulators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kalkulators/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Rodzaj,JednostkaWyjsciowa,Wartosc,JednostkaDocelowa,Przekonwertowane,Data")] Kalkulator kalkulator)
        {
            if (ModelState.IsValid)
            {
                db.Kalkulator.Add(kalkulator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kalkulator);
        }

        // GET: Kalkulators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalkulator kalkulator = db.Kalkulator.Find(id);
            if (kalkulator == null)
            {
                return HttpNotFound();
            }
            return View(kalkulator);
        }

        // POST: Kalkulators/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Rodzaj,JednostkaWyjsciowa,Wartosc,JednostkaDocelowa,Przekonwertowane,Data")] Kalkulator kalkulator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kalkulator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kalkulator);
        }

        // GET: Kalkulators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kalkulator kalkulator = db.Kalkulator.Find(id);
            if (kalkulator == null)
            {
                return HttpNotFound();
            }
            return View(kalkulator);
        }

        // POST: Kalkulators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kalkulator kalkulator = db.Kalkulator.Find(id);
            db.Kalkulator.Remove(kalkulator);
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
