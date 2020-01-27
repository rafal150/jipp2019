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
    public class STATISTICSController : Controller
    {
        private Model db = new Model();

        // GET: STATISTICS
        public ActionResult Index()
        {
            return View(db.STATISTICS.ToList());
        }

        // GET: STATISTICS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATISTICS sTATISTICS = db.STATISTICS.Find(id);
            if (sTATISTICS == null)
            {
                return HttpNotFound();
            }
            return View(sTATISTICS);
        }

        // GET: STATISTICS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: STATISTICS/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_STAT,CONVERTED_FROM_VAL,CONVERTED_TO_VAL,CONVERTED_FROM,CONVERTED_TO,DATE,TYPE")] STATISTICS sTATISTICS)
        {
            if (ModelState.IsValid)
            {
                db.STATISTICS.Add(sTATISTICS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTATISTICS);
        }

        // GET: STATISTICS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATISTICS sTATISTICS = db.STATISTICS.Find(id);
            if (sTATISTICS == null)
            {
                return HttpNotFound();
            }
            return View(sTATISTICS);
        }

        // POST: STATISTICS/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_STAT,CONVERTED_FROM_VAL,CONVERTED_TO_VAL,CONVERTED_FROM,CONVERTED_TO,DATE,TYPE")] STATISTICS sTATISTICS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTATISTICS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTATISTICS);
        }

        // GET: STATISTICS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STATISTICS sTATISTICS = db.STATISTICS.Find(id);
            if (sTATISTICS == null)
            {
                return HttpNotFound();
            }
            return View(sTATISTICS);
        }

        // POST: STATISTICS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STATISTICS sTATISTICS = db.STATISTICS.Find(id);
            db.STATISTICS.Remove(sTATISTICS);
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
