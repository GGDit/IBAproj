using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.EntitiesDTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Specialty { get; set; }
        public int StartTimeOfReceipt { get; set; }
        public int EndTimeOfReceipt { get; set; }
        public int Room { get; set; }
    }
}
