﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudProject.Models;

namespace CrudProject.Controllers
{
    public class productsController : Controller
    {
        private akshopEntities db = new akshopEntities();

      

        public ActionResult Index()
        {
            var products = db.products
                .Include(p => p.brand)
                .Include(p => p.category)
                .ToList();

            return View(products);
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            ViewBag.brand_id = new SelectList(db.brands, "id", "brand1");
            ViewBag.cat_id = new SelectList(db.categories, "id", "category1");
            ViewBag.id = new SelectList(db.products, "id", "prodname");
            ViewBag.id = new SelectList(db.products, "id", "prodname");
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,prodname,cat_id,brand_id,qty,price")] product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brand_id = new SelectList(db.brands, "id", "brand1", product.brand_id);
            ViewBag.cat_id = new SelectList(db.categories, "id", "category1", product.cat_id);
            ViewBag.id = new SelectList(db.products, "id", "prodname", product.id);
            ViewBag.id = new SelectList(db.products, "id", "prodname", product.id);
            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_id = new SelectList(db.brands, "id", "brand1", product.brand_id);
            ViewBag.cat_id = new SelectList(db.categories, "id", "category1", product.cat_id);
            ViewBag.id = new SelectList(db.products, "id", "prodname", product.id);
            ViewBag.id = new SelectList(db.products, "id", "prodname", product.id);
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,prodname,cat_id,brand_id,qty,price")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brand_id = new SelectList(db.brands, "id", "brand1", product.brand_id);
            ViewBag.cat_id = new SelectList(db.categories, "id", "category1", product.cat_id);
            ViewBag.id = new SelectList(db.products, "id", "prodname", product.id);
            ViewBag.id = new SelectList(db.products, "id", "prodname", product.id);
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
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
