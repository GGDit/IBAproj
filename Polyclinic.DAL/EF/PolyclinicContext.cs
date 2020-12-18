using Polyclinic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.EF
{
    class PolyclinicContext : DbContext
    {
        public PolyclinicContext(string connectionString) : base(connectionString)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Record> Records { get; set; }

    }
}
