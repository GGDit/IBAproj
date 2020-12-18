using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polyclinic.Web.Models
{
    public class IndexViewModel
    {
        public List<DoctorViewModel> Doctors { get; set; }
        public List<string> Speciality { get; set; }
    }
}