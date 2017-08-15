using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dmanage2.Models;

namespace dmanage2.Controllers
{
    public class DepartmentsModelsController : Controller
    {
        private dmanage2Context db = new dmanage2Context();

        // GET: DepartmentsModels
        public ActionResult Index()
        {
            return View(db.DepartmentsModels.ToList());
        }

        // GET: DepartmentsModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentsModel departmentsModel = db.DepartmentsModels.Find(id);
            if (departmentsModel == null)
            {
                return HttpNotFound();
            }
            return View(departmentsModel);
        }

        // GET: DepartmentsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,DepartmentName,HOD")] DepartmentsModel departmentsModel)
        {
            if (ModelState.IsValid)
            {
                departmentsModel.DepartmentId = Guid.NewGuid();
                db.DepartmentsModels.Add(departmentsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmentsModel);
        }

        // GET: DepartmentsModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentsModel departmentsModel = db.DepartmentsModels.Find(id);
            if (departmentsModel == null)
            {
                return HttpNotFound();
            }
            return View(departmentsModel);
        }

        // POST: DepartmentsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,DepartmentName,HOD")] DepartmentsModel departmentsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departmentsModel);
        }

        // GET: DepartmentsModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentsModel departmentsModel = db.DepartmentsModels.Find(id);
            if (departmentsModel == null)
            {
                return HttpNotFound();
            }
            return View(departmentsModel);
        }

        // POST: DepartmentsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DepartmentsModel departmentsModel = db.DepartmentsModels.Find(id);
            db.DepartmentsModels.Remove(departmentsModel);
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
