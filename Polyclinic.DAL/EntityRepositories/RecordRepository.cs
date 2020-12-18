using Polyclinic.DAL.EF;
using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.EntityRepositories
{
    class RecordRepository : IRecordRepository
    {
        PolyclinicContext db;
        public RecordRepository(string cnnString)
        {
            db = new PolyclinicContext(cnnString);
        }
        public void Create(Record item)
        {
            db.Records.Add(item);
            db.SaveChanges();
        }

        public void Delete(Record item)
        {
            db.Records.Remove(item);
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

        public IEnumerable<Record> GetAll()
        {
            return db.Records;
        }

        public Record GetById(int id)
        {
            return db.Records.Find(id);
        }

        public void Update(Record item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
