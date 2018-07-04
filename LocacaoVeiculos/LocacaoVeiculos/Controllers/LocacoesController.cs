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
    public class LocacoesController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Locacoes
        public ActionResult Index()
        {
            var locacoes = db.Locacoes.Include(l => l._Cliente).Include(l => l._Usuario).Include(l => l._Veiculo);
            return View(locacoes.ToList());
        }

        // GET: Locacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        // GET: Locacoes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome");
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome");
            ViewBag.VeiculoID = new SelectList(db.Veiculos, "VeiculoID", "Modelo");
            return View();
        }

        // POST: Locacoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocacaoId,DtRetirada,DtDevolucao,VeiculoID,ClienteID,UsuarioID,Observacoes,Opcionais")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                db.Locacoes.Add(locacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", locacao.ClienteID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome", locacao.UsuarioID);
            ViewBag.VeiculoID = new SelectList(db.Veiculos, "VeiculoID", "Modelo", locacao.VeiculoID);
            return View(locacao);
        }

        // GET: Locacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", locacao.ClienteID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome", locacao.UsuarioID);
            ViewBag.VeiculoID = new SelectList(db.Veiculos, "VeiculoID", "Modelo", locacao.VeiculoID);
            return View(locacao);
        }

        // POST: Locacoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocacaoId,DtRetirada,DtDevolucao,VeiculoID,ClienteID,UsuarioID,Observacoes,Opcionais")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", locacao.ClienteID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "Nome", locacao.UsuarioID);
            ViewBag.VeiculoID = new SelectList(db.Veiculos, "VeiculoID", "Modelo", locacao.VeiculoID);
            return View(locacao);
        }

        // GET: Locacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacao locacao = db.Locacoes.Find(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        // POST: Locacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locacao locacao = db.Locacoes.Find(id);
            db.Locacoes.Remove(locacao);
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

       /* public JsonResult GetEvents()
        {
            using (MeuContexto dc = new MeuContexto())
            {
                var event = dc.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            }
        } */

    }
}
