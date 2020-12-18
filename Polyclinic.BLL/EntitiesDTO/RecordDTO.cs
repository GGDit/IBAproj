using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.EntitiesDTO
{
    public class RecordDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }

        public DateTime TimeOfRecord { get; set; }

        public int PatientId { get; set; }
    }
}
