using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polyclinic.Web.Models
{
    public class RecordViewModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
      
        public string TimeOfRecord { get; set; }
        //[Required]
        public string PatientLastname { get; set; }
        //[Required]
        public DateTime Date { get; set; } //дата приема
        public Dictionary<string, int> Time { get; set; } //время приема с указанием: занято (1) или свободно (0)
    }
}