using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalMgtSystem.Models
{
    public class Nurse
    {
        [Key]
        public int NurseId { get; set; }
        public string NurseName { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string JoiningDate { get; set; }
        public List<DayCare> DayCares { get; set; }
    }
}