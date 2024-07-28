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
            CreateMap<Tuple<TimeSpan, TimeSpan>, TimeSlotViewModel>()
                .ForMember(D => D.TimeSlot, O => O.MapFrom(S => $"{S.Item1} - {S.Item2}"))
                .ForMember(D => D.From, O => O.MapFrom(S => S.Item1))
                .ForMember(D => D.To, O => O.MapFrom(S => S.Item2));
                

            
        }

    }
}
