using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NETCRUD1.Models;

namespace ASP.NETCRUD1.Controllers
{
    public class ProductTablesController : Controller
    {
        private NimapEntities db = new NimapEntities();

        // GET: ProductTables
        public ActionResult Index()
        {
            return View(db.ProductTables.ToList());
        }

        // GET: ProductTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable productTable = db.ProductTables.Find(id);
            if (productTable == null)
            {
                return HttpNotFound();
            }
            return View(productTable);
        }

        // GET: ProductTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,CategoryId,CategoryName")] ProductTable productTable)
        {
            if (ModelState.IsValid)
            {
                db.ProductTables.Add(productTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productTable);
        }

        // GET: ProductTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable productTable = db.ProductTables.Find(id);
            if (productTable == null)
            {
                return HttpNotFound();
            }
            return View(productTable);
        }

        // POST: ProductTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,CategoryId,CategoryName")] ProductTable productTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productTable);
        }

        // GET: ProductTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable productTable = db.ProductTables.Find(id);
            if (productTable == null)
            {
                return HttpNotFound();
            }
            return View(productTable);
        }

        // POST: ProductTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductTable productTable = db.ProductTables.Find(id);
            db.ProductTables.Remove(productTable);
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
