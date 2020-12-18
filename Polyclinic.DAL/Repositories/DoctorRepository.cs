using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.DAL.Repositories
{
    class DoctorRepository : IDoctorRepository
    {
        SqlConnection connection;

        public DoctorRepository(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void Create(Doctor item)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Doctors (Lastname,Specialty,StartTimeOfReceipt,EndTimeOfReceipt,Room) VALUES(@lastname,@speciality,@startTimeOfReceipt,@endTimeOfReceipt,@room)", connection);

            command.Parameters.Add("@lastname", System.Data.SqlDbType.NVarChar).Value = item.Lastname;
            command.Parameters.AddWithValue("@speciality", item.Specialty);
            command.Parameters.AddWithValue("@startTimeOfReceipt", item.StartTimeOfReceipt);
            command.Parameters.AddWithValue("@endTimeOfReceipt", item.EndTimeOfReceipt);
            command.Parameters.AddWithValue("@room", item.Room);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Doctor item)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Delete from [dbo].Doctors Where Id = @id", connection);

            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = item.Id;
            command.ExecuteNonQuery();
            connection.Close();
        }



        public IEnumerable<Doctor> GetAll()
        {
            List<Doctor> doctors = new List<Doctor>();
            connection.Open();
            SqlCommand select = connection.CreateCommand();
            select.CommandText = "SELECT * FROM Doctors";

            using (SqlDataReader reader = select.ExecuteReader())
            {
                while (reader.Read())
                {
                    doctors.Add(new Doctor
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Lastname = reader["Lastname"].ToString(),
                        Specialty = reader["Specialty"].ToString(),
                        StartTimeOfReceipt = Convert.ToInt32(reader["StartTimeOfReceipt"]),
                        EndTimeOfReceipt = Convert.ToInt32(reader["EndTimeOfReceipt"]),
                        Room = Convert.ToInt32(reader["Room"])
                    });

                }
            }

            connection.Close();
            return doctors;
        }

        public Doctor GetById(int id)
        {
            connection.Open();
            SqlCommand select = connection.CreateCommand();
            select.Parameters.AddWithValue("@id", id);
            select.CommandText = "SELECT * FROM Doctors WHERE Id=@id";
            Doctor doctor = null;
            using (SqlDataReader reader = select.ExecuteReader())
            {
                if (reader.Read())
                {

                    doctor = new Doctor
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Lastname = reader["Lastname"].ToString(),
                        Specialty = reader["Specialty"].ToString(),
                        StartTimeOfReceipt = Convert.ToInt32(reader["StartTimeOfReceipt"]),
                        EndTimeOfReceipt = Convert.ToInt32(reader["EndTimeOfReceipt"]),
                        Room = Convert.ToInt32(reader["Room"])
                    };
                }

            }
            connection.Close();
            return doctor;

        }

        public void Update(Doctor item)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Doctors SET  Lastname = @p1,Specialty = @p2,StartTimeOfReceipt = @p3,EndTimeOfReceipt=@p4,Room=@p5  WHERE(ID = @id)", connection);

            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = item.Id;
            command.Parameters.Add("@p1", System.Data.SqlDbType.NVarChar).Value = item.Lastname;
            command.Parameters.AddWithValue("@p2", item.Specialty);
            command.Parameters.AddWithValue("@p3", item.StartTimeOfReceipt);
            command.Parameters.AddWithValue("@p4", item.EndTimeOfReceipt);
            command.Parameters.AddWithValue("@p5", item.Room);
            command.ExecuteNonQuery();
            connection.Close();
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
    }

}
