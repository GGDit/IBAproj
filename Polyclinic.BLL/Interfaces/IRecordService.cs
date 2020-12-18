using Polyclinic.BLL.EntitiesDTO;
using System;
using System.Collections.Generic;

namespace Polyclinic.BLL.Interfaces
{
    public interface IRecordService : IDisposable
    {
        void Create(RecordDTO item);
        void Delete(RecordDTO item);
        void Update(RecordDTO item);
        RecordDTO GetById(int id);
        IList<RecordDTO> GetAll();
    }
}
