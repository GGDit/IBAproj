using Polyclinic.BLL.EntitiesDTO;
using System;
using System.Collections.Generic;

namespace Polyclinic.Web.Models
{
    public class ListRecordViewModel
    {
        public IList<DateTime> Dates { get; set; }
        public DoctorDTO Doctor { get; set; }
    }
}