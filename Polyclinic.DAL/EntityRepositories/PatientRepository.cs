using Polyclinic.DAL.EF;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.EntityRepositories
{
    class PatientRepository : IPatientRepository
    {
         PolyclinicContext db;
        public PatientRepository(string connectionString)
        {
            db = new PolyclinicContext(connectionString);
        }
        public void Create(Patient item)
        {
            var lastname = new SqlParameter("@lastname", item.Lastname);
            db.Database.ExecuteSqlCommand("CreatePatient @lastname", lastname);
            db.SaveChanges();
        }

        public void Delete(Patient item)
        {
            var id = new SqlParameter("@id", item.Id);
            db.Database.ExecuteSqlCommand("DeletePatient @id", id);
            db.SaveChanges(); 
        }

        bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Patient> GetAll()
        {
            return db.Patients;
        }

        public Patient GetById(int id)
        {
            return db.Patients.Find(id);
        }

        public void Update(Patient item)
        {
            var id = new SqlParameter("@id", item.Id);
            var lastname = new SqlParameter("@lastname", item.Lastname);
            
            db.Database.ExecuteSqlCommand("UpdatePatient @id,@lastname", id, lastname);
            db.SaveChanges();
        }
    }
}
