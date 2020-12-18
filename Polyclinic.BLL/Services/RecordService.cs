using Polyclinic.BLL.EntitiesDTO;
using Polyclinic.BLL.Interfaces;
using Polyclinic.BLL.PolyclinicMapper;
using Polyclinic.BLL.Validation;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Polyclinic.BLL.Services
{
    public class RecordService : IRecordService
    {
        IDoctorRepository doctorRepository;
        IRecordRepository recordRepository;

        public RecordService(IDoctorRepository doctorRepository, IRecordRepository recordRepository)
        {
            this.doctorRepository = doctorRepository;
            this.recordRepository = recordRepository;
        }

        public void Create(RecordDTO item)
        {
            if (item == null)
                throw new NullReferenceException();
            Record record = MapperP.FromDTO(item);
            string error;
            if (!Validator.IsTimeOfRecordCorrect(record, doctorRepository, out error))
                throw new ArgumentException(error);

            recordRepository.Create(record);
        }

        public void Delete(RecordDTO item)
        {
            if (item == null)
                throw new NullReferenceException();

            Record record = MapperP.FromDTO(item);

            recordRepository.Delete(record);
        }

        public void Dispose()
        {
            recordRepository.Dispose();
            doctorRepository.Dispose();
        }

        public IList<RecordDTO> GetAll()
        {
            List<Record> records = recordRepository.GetAll().ToList();
            List<RecordDTO> list = MapperP.ToDTO(records);              
            return list;
        }

        public RecordDTO GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id  <= 0");

            Record record = recordRepository.GetById(id);
            if (record == null)
                throw new ArgumentException($"Нет записи с ID = {id}");

            RecordDTO recordDTO = MapperP.ToDTO(record);

            return recordDTO;
        }

        public void Update(RecordDTO item)
        {
            if (item == null)
                throw new NullReferenceException();
            Record record = MapperP.FromDTO(item);

            string error;
            if (!Validator.IsTimeOfRecordCorrect(record, doctorRepository, out error))
                throw new ArgumentException(error);

            recordRepository.Update(record);
        }
    }
}
