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
    public class INT_pedidoController : Controller
    {
        private examenEntities db = new examenEntities();

        // GET: INT_pedido
        public ActionResult Index()
        {
            var iNT_pedido = db.INT_pedido.Include(i => i.INT_Clientes).Include(i => i.INT_Venta);
            return View(iNT_pedido.ToList());
        }

        // GET: INT_pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_pedido iNT_pedido = db.INT_pedido.Find(id);
            if (iNT_pedido == null)
            {
                return HttpNotFound();
            }
            return View(iNT_pedido);
        }

        // GET: INT_pedido/Create
        public ActionResult Create()
        {
            ViewBag.Cliente = new SelectList(db.INT_Clientes, "cliRut", "cliNombre");
            ViewBag.Producto = new SelectList(db.INT_Venta, "ventId", "ventNombre");
            return View();
        }

        // POST: INT_pedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pedidoId,Cliente,Producto")] INT_pedido iNT_pedido)
        {
            if (ModelState.IsValid)
            {
                db.INT_pedido.Add(iNT_pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente = new SelectList(db.INT_Clientes, "cliRut", "cliNombre", iNT_pedido.Cliente);
            ViewBag.Producto = new SelectList(db.INT_Venta, "ventId", "ventNombre", iNT_pedido.Producto);
            return View(iNT_pedido);
        }

        // GET: INT_pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_pedido iNT_pedido = db.INT_pedido.Find(id);
            if (iNT_pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente = new SelectList(db.INT_Clientes, "cliRut", "cliNombre", iNT_pedido.Cliente);
            ViewBag.Producto = new SelectList(db.INT_Venta, "ventId", "ventNombre", iNT_pedido.Producto);
            return View(iNT_pedido);
        }

        // POST: INT_pedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pedidoId,Cliente,Producto")] INT_pedido iNT_pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNT_pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente = new SelectList(db.INT_Clientes, "cliRut", "cliNombre", iNT_pedido.Cliente);
            ViewBag.Producto = new SelectList(db.INT_Venta, "ventId", "ventNombre", iNT_pedido.Producto);
            return View(iNT_pedido);
        }

        // GET: INT_pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_pedido iNT_pedido = db.INT_pedido.Find(id);
            if (iNT_pedido == null)
            {
                return HttpNotFound();
            }
            return View(iNT_pedido);
        }

        // POST: INT_pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INT_pedido iNT_pedido = db.INT_pedido.Find(id);
            db.INT_pedido.Remove(iNT_pedido);
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
