using Polyclinic.BLL.EntitiesDTO;
using Polyclinic.BLL.Interfaces;
using Polyclinic.BLL.PolyclinicMapper;
using Polyclinic.BLL.Validation;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public void Create(DoctorDTO item)
        {
            if (item == null)
                throw new NullReferenceException();
            Doctor doctor = MapperP.FromDTO(item);
            string error;
            if (!Validator.isTimeOfReceiptCorrect(doctor, out error))
                throw new ArgumentException(error);

            doctorRepository.Create(doctor);
        }

        public void Delete(DoctorDTO item)
        {
            if (item == null)
                throw new NullReferenceException();

            Doctor doctor = MapperP.FromDTO(item);

            doctorRepository.Delete(doctor);
        }

        public void Dispose()
        {
            doctorRepository.Dispose();
        }

        public IList<DoctorDTO> GetAll()
        {
            List<Doctor> doctors = doctorRepository.GetAll().ToList();
            List<DoctorDTO> list = MapperP.ToDTO(doctors);

            return list;
        }

        public DoctorDTO GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id  <= 0");

            Doctor doctor = doctorRepository.GetById(id);
            if (doctor == null)
                throw new ArgumentException($"Нет врача с ID = {id}");

            DoctorDTO doctorDTO = MapperP.ToDTO(doctor);

            return doctorDTO;
        }

        public void Update(DoctorDTO item)
        {
            if (item == null)
                throw new NullReferenceException();

            Doctor doctor = MapperP.FromDTO(item);
            string error;
            if (!Validator.isTimeOfReceiptCorrect(doctor, out error))
                throw new ArgumentException(error);

            doctorRepository.Update(doctor);
        }
    }
}
