using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using renthubmap.Models;

namespace renthubmap.Controllers
{
    public class DTOContainersController : Controller
    {
        private RenthubDBContext db = new RenthubDBContext();

        // GET: DTOContainers
        public ActionResult Index()
        {
            return View(db.DTOContainers.ToList());
        }

        // GET: DTOContainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTOContainer dTOContainer = db.DTOContainers.Find(id);
            if (dTOContainer == null)
            {
                return HttpNotFound();
            }
            return View(dTOContainer);
        }

        // GET: DTOContainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DTOContainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,link")] DTOContainer dTOContainer)
        {
            if (ModelState.IsValid)
            {
                db.DTOContainers.Add(dTOContainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dTOContainer);
        }

        // GET: DTOContainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTOContainer dTOContainer = db.DTOContainers.Find(id);
            if (dTOContainer == null)
            {
                return HttpNotFound();
            }
            return View(dTOContainer);
        }

        // POST: DTOContainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,link")] DTOContainer dTOContainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dTOContainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dTOContainer);
        }

        // GET: DTOContainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTOContainer dTOContainer = db.DTOContainers.Find(id);
            if (dTOContainer == null)
            {
                return HttpNotFound();
            }
            return View(dTOContainer);
        }

        // POST: DTOContainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DTOContainer dTOContainer = db.DTOContainers.Find(id);
            db.DTOContainers.Remove(dTOContainer);
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
