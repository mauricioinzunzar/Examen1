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
    public class INT_ClientesController : Controller
    {
        private examenEntities db = new examenEntities();

        // GET: INT_Clientes
        public ActionResult Index()
        {
            var iNT_Clientes = db.INT_Clientes.Include(i => i.INT_Tipocliente);
            return View(iNT_Clientes.ToList());
        }

        // GET: INT_Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_Clientes iNT_Clientes = db.INT_Clientes.Find(id);
            if (iNT_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(iNT_Clientes);
        }

        // GET: INT_Clientes/Create
        public ActionResult Create()
        {
            ViewBag.Tipocliente = new SelectList(db.INT_Tipocliente, "Id", "Tipocliente");
            return View();
        }

        // POST: INT_Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cliRut,cliNombre,cliDApellido,cliDireccion,Tipocliente")] INT_Clientes iNT_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.INT_Clientes.Add(iNT_Clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipocliente = new SelectList(db.INT_Tipocliente, "Id", "Tipocliente", iNT_Clientes.Tipocliente);
            return View(iNT_Clientes);
        }

        // GET: INT_Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_Clientes iNT_Clientes = db.INT_Clientes.Find(id);
            if (iNT_Clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipocliente = new SelectList(db.INT_Tipocliente, "Id", "Tipocliente", iNT_Clientes.Tipocliente);
            return View(iNT_Clientes);
        }

        // POST: INT_Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cliRut,cliNombre,cliDApellido,cliDireccion,Tipocliente")] INT_Clientes iNT_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNT_Clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipocliente = new SelectList(db.INT_Tipocliente, "Id", "Tipocliente", iNT_Clientes.Tipocliente);
            return View(iNT_Clientes);
        }

        // GET: INT_Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INT_Clientes iNT_Clientes = db.INT_Clientes.Find(id);
            if (iNT_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(iNT_Clientes);
        }

        // POST: INT_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INT_Clientes iNT_Clientes = db.INT_Clientes.Find(id);
            db.INT_Clientes.Remove(iNT_Clientes);
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
