using Polyclinic.BLL.EntitiesDTO;
using System;
using System.Collections.Generic;

namespace Polyclinic.BLL.Interfaces
{
    public  interface IDoctorService:IDisposable
    {
        void Create(DoctorDTO item);
        void Delete(DoctorDTO item);
        void Update(DoctorDTO item);
        DoctorDTO GetById(int id);
        IList<DoctorDTO> GetAll();
    }
}
