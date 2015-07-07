using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNETIdentity_GoogleAuthenticator.Concrete;
using ASPNETIdentity_GoogleAuthenticator.Models;

namespace ASPNETIdentity_GoogleAuthenticator.Controllers
{
    public class tesrController : Controller
    {
        private AuditingContext db = new AuditingContext();

        // GET: tesr
        public ActionResult Index()
        {
            return View(db.AuditRecords.ToList());
        }

        // GET: tesr/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = db.AuditRecords.Find(id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            return View(audit);
        }

        // GET: tesr/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tesr/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuditID,UserName,IPAddress,AreaAccessed,TimeAccessed")] Audit audit)
        {
            if (ModelState.IsValid)
            {
                audit.AuditID = Guid.NewGuid();
                db.AuditRecords.Add(audit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(audit);
        }

        // GET: tesr/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = db.AuditRecords.Find(id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            return View(audit);
        }

        // POST: tesr/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuditID,UserName,IPAddress,AreaAccessed,TimeAccessed")] Audit audit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(audit);
        }

        // GET: tesr/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = db.AuditRecords.Find(id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            return View(audit);
        }

        // POST: tesr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Audit audit = db.AuditRecords.Find(id);
            db.AuditRecords.Remove(audit);
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
