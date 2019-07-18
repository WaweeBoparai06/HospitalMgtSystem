using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalMgtSystem.Models;

namespace HospitalMgtSystem.Controllers
{
    public class DayCaresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DayCares
        public ActionResult Index()
        {
            var dayCares = db.DayCares.Include(d => d.Doctor).Include(d => d.Nurse).Include(d => d.Patient);
            return View(dayCares.ToList());
        }

        // GET: DayCares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayCare dayCare = db.DayCares.Find(id);
            if (dayCare == null)
            {
                return HttpNotFound();
            }
            return View(dayCare);
        }

        // GET: DayCares/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName");
            ViewBag.NurseId = new SelectList(db.Nurses, "NurseId", "NurseName");
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName");
            return View();
        }

        // POST: DayCares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DayCareId,PatientId,DoctorId,VisitTime,NurseId")] DayCare dayCare)
        {
            if (ModelState.IsValid)
            {
                db.DayCares.Add(dayCare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", dayCare.DoctorId);
            ViewBag.NurseId = new SelectList(db.Nurses, "NurseId", "NurseName", dayCare.NurseId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName", dayCare.PatientId);
            return View(dayCare);
        }

        // GET: DayCares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayCare dayCare = db.DayCares.Find(id);
            if (dayCare == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", dayCare.DoctorId);
            ViewBag.NurseId = new SelectList(db.Nurses, "NurseId", "NurseName", dayCare.NurseId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName", dayCare.PatientId);
            return View(dayCare);
        }

        // POST: DayCares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DayCareId,PatientId,DoctorId,VisitTime,NurseId")] DayCare dayCare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dayCare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", dayCare.DoctorId);
            ViewBag.NurseId = new SelectList(db.Nurses, "NurseId", "NurseName", dayCare.NurseId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName", dayCare.PatientId);
            return View(dayCare);
        }

        // GET: DayCares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayCare dayCare = db.DayCares.Find(id);
            if (dayCare == null)
            {
                return HttpNotFound();
            }
            return View(dayCare);
        }

        // POST: DayCares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DayCare dayCare = db.DayCares.Find(id);
            db.DayCares.Remove(dayCare);
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
