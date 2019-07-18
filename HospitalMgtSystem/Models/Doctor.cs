using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMgtSystem.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public string Experience { get; set; }
        public string ExpDetail { get; set; }
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string JoiningDate { get; set; }
        public int Status { get; set; }
        public List<OPDRegistration> oPDRegistrations { get; set; }
        public List<PatientAdmission> PatientAdmissions { get; set; }
        public List<DayCare> DayCares { get; set; }
    }
}