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
        public ActionResult Index(int? id)
        {
            if(id == null)
            {
                var itemPedido = db.ItemPedidoes.Include(i => i.Pedido).Include(i => i.Produto);
                return View(itemPedido.ToList());
            }

            var itemPedidoes = db.ItemPedidoes.Include(i => i.Pedido).Include(i => i.Produto);
            return View(itemPedidoes.Where(p => p.PedidoId == id).ToList());
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
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId");
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "Nome");
            return View();
        }

        // POST: ItemPedidoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemPedidoId,Quantidade,Observacoes,ProdutoId,PedidoId")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                db.ItemPedidoes.Add(itemPedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId", itemPedido.PedidoId);
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
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId", itemPedido.PedidoId);
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "ProdutoId", "Nome", itemPedido.ProdutoId);
            return View(itemPedido);
        }

        // POST: ItemPedidoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemPedidoId,Quantidade,Observacoes,ProdutoId,PedidoId")] ItemPedido itemPedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemPedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId", itemPedido.PedidoId);
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
