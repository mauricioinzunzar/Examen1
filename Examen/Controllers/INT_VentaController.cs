using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen.Models;

namespace Examen.Controllers
{
    public class INT_VentaController : Controller
    {
        private examenEntities db = new examenEntities();

        // GET: INT_Venta
        public ActionResult Index()
        {
            return View(db.INT_Venta.ToList());
        }

        // GET: INT_Venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_Venta iNT_Venta = db.INT_Venta.Find(id);
            if (iNT_Venta == null)
            {
                return HttpNotFound();
            }
            return View(iNT_Venta);
        }

        // GET: INT_Venta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: INT_Venta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ventId,ventNombre,ventCodigo,ventFamilia,ventPrecio,ventDescuento,ventDescripcion")] INT_Venta iNT_Venta)
        {
            if (ModelState.IsValid)
            {
                db.INT_Venta.Add(iNT_Venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iNT_Venta);
        }

        // GET: INT_Venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_Venta iNT_Venta = db.INT_Venta.Find(id);
            if (iNT_Venta == null)
            {
                return HttpNotFound();
            }
            return View(iNT_Venta);
        }

        // POST: INT_Venta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ventId,ventNombre,ventCodigo,ventFamilia,ventPrecio,ventDescuento,ventDescripcion")] INT_Venta iNT_Venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNT_Venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iNT_Venta);
        }

        // GET: INT_Venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_Venta iNT_Venta = db.INT_Venta.Find(id);
            if (iNT_Venta == null)
            {
                return HttpNotFound();
            }
            return View(iNT_Venta);
        }

        // POST: INT_Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INT_Venta iNT_Venta = db.INT_Venta.Find(id);
            db.INT_Venta.Remove(iNT_Venta);
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
