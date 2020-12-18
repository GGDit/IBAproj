namespace Polyclinic.Web.Models
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Specialty { get; set; }
        public int StartTimeOfReceipt { get; set; }
        public int EndTimeOfReceipt { get; set; }
        public int Room { get; set; }
    }
}