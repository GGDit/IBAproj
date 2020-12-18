using Polyclinic.DAL.EF;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Polyclinic.DAL.EntityRepositories
{
    class DoctorRepository : IDoctorRepository
    {
        PolyclinicContext db;

        public DoctorRepository(string connectionString)
        {
            this.db = new PolyclinicContext(connectionString);
        }

        public void Create(Doctor item)
        {
            db.Doctors.Add(item);
            db.SaveChanges();
        }

        public void Delete(Doctor item)
        {
            db.Doctors.Remove(item);
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

        public IEnumerable<Doctor> GetAll()
        {
            return db.Doctors.ToList();
        }

        public Doctor GetById(int id)
        {
            return db.Doctors.Find(id);
        }

        public void Update(Doctor item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
