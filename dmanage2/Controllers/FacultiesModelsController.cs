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
    public class FacultiesModelsController : Controller
    {
        private dmanage2Context db = new dmanage2Context();

        // GET: FacultiesModels
        public ActionResult Index()
        {
            var facultiesModels = db.FacultiesModels.Include(f => f.Department);
            return View(facultiesModels.ToList());
        }

        // GET: FacultiesModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultiesModel facultiesModel = db.FacultiesModels.Find(id);
            if (facultiesModel == null)
            {
                return HttpNotFound();
            }
            return View(facultiesModel);
        }

        // GET: FacultiesModels/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentsId = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: FacultiesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FacultyName,DepartmentsId")] FacultiesModel facultiesModel)
        {
            if (ModelState.IsValid)
            {
                facultiesModel.Id = Guid.NewGuid();
                db.FacultiesModels.Add(facultiesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentsId = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName", facultiesModel.DepartmentsId);
            return View(facultiesModel);
        }

        // GET: FacultiesModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultiesModel facultiesModel = db.FacultiesModels.Find(id);
            if (facultiesModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentsId = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName", facultiesModel.DepartmentsId);
            return View(facultiesModel);
        }

        // POST: FacultiesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FacultyName,DepartmentsId")] FacultiesModel facultiesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facultiesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentsId = new SelectList(db.DepartmentsModels, "DepartmentId", "DepartmentName", facultiesModel.DepartmentsId);
            return View(facultiesModel);
        }

        // GET: FacultiesModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacultiesModel facultiesModel = db.FacultiesModels.Find(id);
            if (facultiesModel == null)
            {
                return HttpNotFound();
            }
            return View(facultiesModel);
        }

        // POST: FacultiesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FacultiesModel facultiesModel = db.FacultiesModels.Find(id);
            db.FacultiesModels.Remove(facultiesModel);
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
