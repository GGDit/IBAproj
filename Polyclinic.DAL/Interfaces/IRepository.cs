using System;
using System.Collections.Generic;

namespace Polyclinic.DAL.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Create(T item);
        void Delete(T item);
        void Update(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
