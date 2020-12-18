using Polyclinic.BLL.EntitiesDTO;
using System;
using System.Collections.Generic;

namespace Polyclinic.BLL.Interfaces
{

    public interface IPatientService : IDisposable
    {
        void Create(PatientDTO item);
        void Delete(PatientDTO item);
        void Update(PatientDTO item);
        PatientDTO GetById(int id);
        IList<PatientDTO> GetAll();
    }
}
