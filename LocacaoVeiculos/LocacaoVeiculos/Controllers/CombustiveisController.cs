using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LocacaoVeiculos.Models;
using LocacaoVeiculos.Models.DAL;

namespace LocacaoVeiculos
{
    public class CombustiveisController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Combustiveis
        public ActionResult Index()
        {
            return View(db.Combustiveis.ToList());
        }

        // GET: Combustiveis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combustivel combustivel = db.Combustiveis.Find(id);
            if (combustivel == null)
            {
                return HttpNotFound();
            }
            return View(combustivel);
        }

        // GET: Combustiveis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Combustiveis/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CombustivelID,combustivel")] Combustivel combustivel)
        {
            if (ModelState.IsValid)
            {
                db.Combustiveis.Add(combustivel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(combustivel);
        }

        // GET: Combustiveis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combustivel combustivel = db.Combustiveis.Find(id);
            if (combustivel == null)
            {
                return HttpNotFound();
            }
            return View(combustivel);
        }

        // POST: Combustiveis/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CombustivelID,combustivel")] Combustivel combustivel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(combustivel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(combustivel);
        }

        // GET: Combustiveis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combustivel combustivel = db.Combustiveis.Find(id);
            if (combustivel == null)
            {
                return HttpNotFound();
            }
            return View(combustivel);
        }

        // POST: Combustiveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Combustivel combustivel = db.Combustiveis.Find(id);
            db.Combustiveis.Remove(combustivel);
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
