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
    public class VeiculosController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Veiculos
        public ActionResult Index()
        {
            var veiculos = db.Veiculos.Include(v => v._Combustivel).Include(v => v._Cor).Include(v => v._Marca).Include(v => v._Tipo);
            return View(veiculos.ToList());
        }

        // GET: Veiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculos/Create
        public ActionResult Create()
        {
            ViewBag.CombustivelID = new SelectList(db.Combustiveis, "CombustivelID", "combustivel");
            ViewBag.CorID = new SelectList(db.Cores, "CorID", "cor");
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "marca");
            ViewBag.TipoID = new SelectList(db.Tipos, "TipoID", "tipo");
            return View();
        }

        // POST: Veiculos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VeiculoID,Modelo,MarcaID,CorID,Ano,CombustivelID,TipoID,Detalhes,Versao")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Veiculos.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CombustivelID = new SelectList(db.Combustiveis, "CombustivelID", "combustivel", veiculo.CombustivelID);
            ViewBag.CorID = new SelectList(db.Cores, "CorID", "cor", veiculo.CorID);
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "marca", veiculo.MarcaID);
            ViewBag.TipoID = new SelectList(db.Tipos, "TipoID", "tipo", veiculo.TipoID);
            return View(veiculo);
        }

        // GET: Veiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CombustivelID = new SelectList(db.Combustiveis, "CombustivelID", "combustivel", veiculo.CombustivelID);
            ViewBag.CorID = new SelectList(db.Cores, "CorID", "cor", veiculo.CorID);
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "marca", veiculo.MarcaID);
            ViewBag.TipoID = new SelectList(db.Tipos, "TipoID", "tipo", veiculo.TipoID);
            return View(veiculo);
        }

        // POST: Veiculos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VeiculoID,Modelo,MarcaID,CorID,Ano,CombustivelID,TipoID,Detalhes,Versao")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CombustivelID = new SelectList(db.Combustiveis, "CombustivelID", "combustivel", veiculo.CombustivelID);
            ViewBag.CorID = new SelectList(db.Cores, "CorID", "cor", veiculo.CorID);
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "marca", veiculo.MarcaID);
            ViewBag.TipoID = new SelectList(db.Tipos, "TipoID", "tipo", veiculo.TipoID);
            return View(veiculo);
        }

        // GET: Veiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veiculo veiculo = db.Veiculos.Find(id);
            db.Veiculos.Remove(veiculo);
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
