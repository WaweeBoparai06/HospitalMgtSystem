using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMgtSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string DateOfRegister { get; set; }
        public string Gender { get; set; }
        public int Status { get; set; }
        public string Remarks { get; set; }
        public List<OPDRegistration> oPDRegistrations { get; set; }
        public List<PatientAdmission> PatientAdmissions { get; set; }
        public List<DayCare> DayCares { get; set; }
    }
}