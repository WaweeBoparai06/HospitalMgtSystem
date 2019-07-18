using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMgtSystem.Models
{
    public class DayCare
    {
        [Key]
        public int DayCareId { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string VisitTime { get; set; }
        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }

    }
}