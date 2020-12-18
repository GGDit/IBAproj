using AutoMapper;
using Polyclinic.BLL.EntitiesDTO;
using Polyclinic.BLL.Interfaces;
using Polyclinic.BLL.MapperProfiles;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace Polyclinic.BLL.Services
{
    public class PatientService:IPatientService
    {
        IPatientRepository patientRepository;
        IMapper mapper;
        public PatientService(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PatientProfile());
                
            });
            mapper = mappingConfig.CreateMapper();
        }

        public void Create(PatientDTO item)
        {
            if (item == null)
                throw new NullReferenceException();

            var patient = mapper.Map<Patient>(item);
            if (patientRepository.GetById(patient.Id) != null)
            {
                throw new Exception($"Пациент '{patient.Lastname}'  уже есть в базе ");
            }
            patientRepository.Create(patient);

        }

        public void Delete(PatientDTO item)
        {
            if (item == null)
                throw new NullReferenceException();
            var patient = mapper.Map<Patient>(item);
            patientRepository.Delete(patient);
        }

        public void Dispose()
        {
            patientRepository.Dispose();
        }

        public IList<PatientDTO> GetAll()
        {
            var patients = patientRepository.GetAll();
            List<PatientDTO> list = mapper.Map<List<PatientDTO>>(patients);
            return list;
        }

        public PatientDTO GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id  <= 0");
            var patient = patientRepository.GetById(id);
            if (patient == null)
                throw new ArgumentException($"Нет пациента с ID = {id}");
            var patientDTO = mapper.Map<PatientDTO>(patient);

            return patientDTO;
        }

        public void Update(PatientDTO item)
        {
            if (item == null)
                throw new NullReferenceException();

            var patient = mapper.Map<Patient>(item);
            if (patientRepository.GetById(patient.Id) == null)
                throw new Exception($"Пациента '{patient.Lastname}' нет в базе");

            patientRepository.Update(patient);
        }
    }
}
