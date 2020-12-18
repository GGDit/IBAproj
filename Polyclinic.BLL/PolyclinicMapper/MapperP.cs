using Polyclinic.BLL.EntitiesDTO;
using Polyclinic.DAL.Entities;
using System.Collections.Generic;

namespace Polyclinic.BLL.PolyclinicMapper
{
    public static class MapperP
    {
        public static DoctorDTO ToDTO(Doctor item)
        {
            DoctorDTO doc = new DoctorDTO
            {
                Id = item.Id,
                Lastname = item.Lastname,
                Specialty = item.Specialty,
                StartTimeOfReceipt = item.StartTimeOfReceipt,
                EndTimeOfReceipt = item.EndTimeOfReceipt,
                Room = item.Room
            };
            return doc;
        }
        public static Doctor FromDTO(DoctorDTO item)
        {
            Doctor doc = new Doctor
            {
                Id = item.Id,
                Lastname = item.Lastname,
                Specialty = item.Specialty,
                StartTimeOfReceipt = item.StartTimeOfReceipt,
                EndTimeOfReceipt = item.EndTimeOfReceipt,
                Room = item.Room
            };
            return doc;
        }
        public static RecordDTO ToDTO(Record item)
        {
            RecordDTO rec = new RecordDTO
            {
                Id = item.Id,
                DoctorId = item.DoctorId,
                TimeOfRecord = item.TimeOfRecord,
                PatientId = item.PatientId
            };
            return rec;
        }
        public static Record FromDTO(RecordDTO item)
        {
            Record rec = new Record
            {
                Id = item.Id,
                DoctorId = item.DoctorId,
                TimeOfRecord = item.TimeOfRecord,
                PatientId = item.PatientId
            };
            return rec;
        }
        public static List<DoctorDTO> ToDTO(List<Doctor> list)
        {
            List<DoctorDTO> doctors = new List<DoctorDTO>();
            foreach (var item in list)
            {
                doctors.Add(new DoctorDTO
                {
                    Id = item.Id,
                    Lastname = item.Lastname,
                    Specialty = item.Specialty,
                    StartTimeOfReceipt = item.StartTimeOfReceipt,
                    EndTimeOfReceipt = item.EndTimeOfReceipt,
                    Room = item.Room
                });
            }
            return doctors;
        }
        public static List<RecordDTO> ToDTO(List<Record> list)
        {
            List<RecordDTO> records = new List<RecordDTO>();
            foreach (var item in list)
            {
                records.Add(new RecordDTO
                {
                    Id = item.Id,
                    DoctorId = item.DoctorId,
                    TimeOfRecord = item.TimeOfRecord,
                    PatientId = item.PatientId
                });
            }
            return records;
        }
    }
}
