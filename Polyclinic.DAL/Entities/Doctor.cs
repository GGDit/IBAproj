namespace Polyclinic.DAL.Entities
{
    //https://habr.com/ru/post/268371/ DTO vs POCO vs Value Object
    public class Doctor
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Specialty { get; set; }
        public int StartTimeOfReceipt { get; set; }
        public int EndTimeOfReceipt { get; set; }
        public int Room { get; set; }
    }
}
