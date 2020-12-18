using AutoMapper;
using Polyclinic.BLL.EntitiesDTO;
using Polyclinic.DAL.Entities;

namespace Polyclinic.BLL.MapperProfiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientDTO>()
                .ForMember(p => p.Surname, opt => opt.MapFrom(pp => pp.Lastname))
                .ReverseMap();
        }
    }
}
