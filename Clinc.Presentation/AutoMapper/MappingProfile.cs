using AutoMapper;
using Clinc.Presentation.ViewModels;
using Clinic.Core.Entities;

namespace Clinc.Presentation.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorViewModel>();
            CreateMap<AppointmentViewModel, Appointment>().ReverseMap()
                .ForMember(D=>D.DoctorName,O=>O.MapFrom(S=>S.Doctor.Name));
            CreateMap<KeyValuePair<double, double>, TimeSlotViewModel>()
                .ForMember(D => D.TimeSlot, O => O.MapFrom(S => $"{S.Key} - {S.Value}"))
                .ForMember(D => D.From, O => O.MapFrom(S => S.Key))
                .ForMember(D => D.To, O => O.MapFrom(S => S.Value));
                

            
        }

    }
}
