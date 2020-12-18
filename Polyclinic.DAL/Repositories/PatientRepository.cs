using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Polyclinic.DAL.Repositories
{
    class PatientRepository : IPatientRepository
    {
        SqlConnection connection;
        public PatientRepository(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }
        public void Create(Patient item)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("CreatePatient", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = item.Lastname;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Patient item)
        {
            if (item != null)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("DeletePatient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", item.Id);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    connection.Dispose();
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
            List<Patient> patients = new List<Patient>();
            connection.Open();
            SqlCommand select = connection.CreateCommand();
            select.CommandText = "SELECT * FROM Patients";
            using (SqlDataReader reader = select.ExecuteReader())
            {
                while (reader.Read())
                {
                    patients.Add(new Patient
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Lastname = reader["lastname"].ToString()
                    });

                }
            }

            connection.Close();
            return patients;
        }

        public Patient GetById(int id)
        {
            connection.Open();
            SqlCommand select = connection.CreateCommand();
            select.Parameters.AddWithValue("@id", id);
            select.CommandText = "SELECT Lastname FROM Patients WHERE Id=@id";
            Patient patient = null;
            var lastname = select.ExecuteScalar();
            if (lastname != null)
                patient = new Patient
                {
                    Id = id,
                    Lastname = lastname.ToString()
                };
            connection.Close();
            return patient;
        }

        public void Update(Patient item)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UpdatePatient", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", item.Id);
            command.Parameters.AddWithValue("@lastname", item.Lastname);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
