using Polyclinic.DAL.Entities;
using Polyclinic.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Polyclinic.DAL.Repositories
{
    class RecordRepository : IRecordRepository
    {
        SqlConnection connection;
        SqlCommand cmd;
        public RecordRepository(string cnnString)
        {
            connection = new SqlConnection(cnnString);
            cmd = connection.CreateCommand();
        }
        public void Create(Record item)
        {
            connection.Open();
            cmd.CommandText = "INSERT INTO Records(DoctorId, TimeOfRecord, PatientId) VALUES(@doctorId, @timeOfRecord, @PatientId)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@doctorId", item.DoctorId);
            cmd.Parameters.AddWithValue("@timeOfRecord", item.TimeOfRecord);
            cmd.Parameters.AddWithValue("@PatientId", item.PatientId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Record item)
        {
            connection.Open();
            cmd.CommandText = "Delete from [dbo].Records Where Id = @id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.ExecuteNonQuery();
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

        public IEnumerable<Record> GetAll()
        {
            List<Record> records = new List<Record>();
            connection.Open();
            
            cmd.CommandText = "SELECT * FROM Records";

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(new Record
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        DoctorId = Convert.ToInt32(reader["DoctorId"]),
                        TimeOfRecord = Convert.ToDateTime(reader["TimeOfRecord"]),
                        PatientId = Convert.ToInt32(reader["PatientId"])
                    });

                }
            }

            connection.Close();
            return records;
        }

        public Record GetById(int id)
        {
            connection.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "SELECT * FROM Records WHERE Id=@id";
            Record record = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {

                    record = new Record
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        DoctorId = Convert.ToInt32(reader["DoctorId"]),
                        TimeOfRecord = Convert.ToDateTime(reader["TimeOfRecord"]),
                        PatientId = Convert.ToInt32(reader["PatientId"])
                    };
                }

            }
            connection.Close();
            return record;
        }

        public void Update(Record item)
        {
            connection.Open();
            cmd.CommandText = "UPDATE Records SET  DoctorId = @p1,TimeOfRecord = @p2,PatientId = @p3  WHERE(ID = @id)";
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = item.Id;
            cmd.Parameters.Add("@p1", System.Data.SqlDbType.NVarChar).Value = item.DoctorId;
            cmd.Parameters.AddWithValue("@p2", item.TimeOfRecord);
            cmd.Parameters.AddWithValue("@p3", item.PatientId);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
