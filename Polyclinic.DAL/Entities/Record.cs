using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.Entities
{
  public  class Record
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }

        public DateTime TimeOfRecord { get; set; }

        public int PatientId { get; set; }
    }
}
