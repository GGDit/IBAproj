//using Polyclinic.DAL.Interfaces;
//using Polyclinic.DAL.Repositories;
using Microsoft.AspNet.Identity;
using Polyclinic.DAL.EF.Identity;
using Polyclinic.DAL.Entities.Identity;
using System;
using System.Data.SqlClient;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = @"(localdb)\mssqllocaldb";
            connectionStringBuilder.InitialCatalog = "PolyclinicDatabase";
            connectionStringBuilder.IntegratedSecurity = true;

            using (PolyclinicUserManager userManager = new PolyclinicUserManager(connectionStringBuilder.ConnectionString))
            {
                userManager.Create(new User
                {
                    Email = "pIv@mail.ru",
                    UserName = "Boss"
                }, "123456");
            }
            //using (IPatientRepository patientRepository = new PatientRepository(connectionStringBuilder.ConnectionString))
            //{
            //    //patientRepository.Create(new Polyclinic.DAL.Entities.Patient { Lastname = "Леди ГАГА" });
            //    foreach (var item in patientRepository.GetAll())
            //    {
            //        Console.WriteLine(item.Id+"  "+item.Lastname);
            //    }
            //    Console.WriteLine("1-й пациент: "+patientRepository.GetById(1).Lastname);
            //    //patientRepository.Delete(patientRepository.GetById(4));
            //    foreach (var item in patientRepository.GetAll())
            //    {
            //        Console.WriteLine(item.Id + "  " + item.Lastname);
            //    }
            //}
            //ServiceModule sm = new ServiceModule(connectionStringBuilder.ConnectionString);
            //IKernel ninjectKernel = new StandardKernel(sm);
            //using (IPatientService patientService = (PatientService)ninjectKernel.Get(typeof(PatientService)))
            //{
            //    patientService.Create(new PatientDTO
            //    {
            //        Id = 567,
            //        Surname = "Меркель"
            //    });
            //}
            Console.WriteLine("Уже все создалось");
                Console.ReadKey();


        }
    }
}
