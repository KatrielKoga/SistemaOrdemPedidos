using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaOrdemPedidos.Models;

namespace SistemaOrdemPedidos.Controllers
{
    public class ItemPedidoesController : Controller
    {
        private SistemaOrdemPedidosContext db = new SistemaOrdemPedidosContext();

        // GET: ItemPedidoes
        public ActionResult Index()
        {
            var itemPedidoes = db.ItemPedidoes.Include(i => i.Cliente).Include(i => i.Produto);
            return View(itemPedidoes.ToList());
        }

        // GET: ItemPedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemPedidoes.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "Nome");
            return View();
        }

        // POST: ItemPedidoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemPedidoId,Quantidade,Observacoes,ProdutoId,ClienteId")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                db.ItemPedidoes.Add(itemPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", itemPedido.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "Nome", itemPedido.ProdutoId);
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemPedidoes.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", itemPedido.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "Nome", itemPedido.ProdutoId);
            return View(itemPedido);
        }

        // POST: ItemPedidoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemPedidoId,Quantidade,Observacoes,ProdutoId,ClienteId")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", itemPedido.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "Nome", itemPedido.ProdutoId);
            return View(itemPedido);
        }

        // GET: ItemPedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedido itemPedido = db.ItemPedidoes.Find(id);
            if (itemPedido == null)
            {
                return HttpNotFound();
            }
            return View(itemPedido);
        }

        // POST: ItemPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemPedido itemPedido = db.ItemPedidoes.Find(id);
            db.ItemPedidoes.Remove(itemPedido);
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
