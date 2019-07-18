using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMgtSystem.Models
{
    public class PatientAdmission
    {
        [Key]
        public int PatientAdmissionId { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int RoomNo { get; set; }
        public string DateOfAdmission { get; set; }
        public string DateOfDischarge { get; set; }
        public string Remarks { get; set; }
        public string RemarkOfDischarge { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}