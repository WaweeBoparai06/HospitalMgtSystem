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
    public class PatientAdmissionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PatientAdmissions
        public ActionResult Index()
        {
            var patientAdmissions = db.PatientAdmissions.Include(p => p.Doctor).Include(p => p.Patient);
            return View(patientAdmissions.ToList());
        }

        // GET: PatientAdmissions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientAdmission patientAdmission = db.PatientAdmissions.Find(id);
            if (patientAdmission == null)
            {
                return HttpNotFound();
            }
            return View(patientAdmission);
        }

        // GET: PatientAdmissions/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName");
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName");
            return View();
        }

        // POST: PatientAdmissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientAdmissionId,PatientId,RoomNo,DateOfAdmission,DateOfDischarge,Remarks,RemarkOfDischarge,DoctorId")] PatientAdmission patientAdmission)
        {
            if (ModelState.IsValid)
            {
                db.PatientAdmissions.Add(patientAdmission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", patientAdmission.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName", patientAdmission.PatientId);
            return View(patientAdmission);
        }

        // GET: PatientAdmissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientAdmission patientAdmission = db.PatientAdmissions.Find(id);
            if (patientAdmission == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", patientAdmission.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName", patientAdmission.PatientId);
            return View(patientAdmission);
        }

        // POST: PatientAdmissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientAdmissionId,PatientId,RoomNo,DateOfAdmission,DateOfDischarge,Remarks,RemarkOfDischarge,DoctorId")] PatientAdmission patientAdmission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientAdmission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorName", patientAdmission.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientName", patientAdmission.PatientId);
            return View(patientAdmission);
        }

        // GET: PatientAdmissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientAdmission patientAdmission = db.PatientAdmissions.Find(id);
            if (patientAdmission == null)
            {
                return HttpNotFound();
            }
            return View(patientAdmission);
        }

        // POST: PatientAdmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientAdmission patientAdmission = db.PatientAdmissions.Find(id);
            db.PatientAdmissions.Remove(patientAdmission);
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
