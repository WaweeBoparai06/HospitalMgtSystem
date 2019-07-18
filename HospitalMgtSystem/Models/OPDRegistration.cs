using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMgtSystem.Models
{
    public class OPDRegistration
    {
        [Key]
        public int OPDId { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string DateOfRegister { get; set; }
        public string Problem { get; set; }
        public int RoomNo { get; set; }
        public int TokenNo { get; set; }
        public int Status { get; set; }
    }
}