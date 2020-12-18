using Ninject.Modules;
using Polyclinic.BLL.Interfaces;
using Polyclinic.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polyclinic.Web.Infrastructure
{
    public class PolyclinicNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDoctorService>().To<DoctorService>();
            Bind<IRecordService>().To<RecordService>();
            Bind<IPatientService>().To<PatientService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}