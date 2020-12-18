using Ninject.Modules;
//using Polyclinic.DAL.Repositories;
using Polyclinic.DAL.EntityRepositories;
using Polyclinic.DAL.Interfaces;
using Polyclinic.DAL.Repositories.Identity;

namespace Polyclinic.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        string connectionString;
        public ServiceModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IPatientRepository>().To<PatientRepository>().WithConstructorArgument(connectionString);
            Bind<IDoctorRepository>().To<DoctorRepository>().WithConstructorArgument(connectionString);
            Bind<IRecordRepository>().To<RecordRepository>().WithConstructorArgument(connectionString);
            Bind<IUnitOfWork>().To<IdentityUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
