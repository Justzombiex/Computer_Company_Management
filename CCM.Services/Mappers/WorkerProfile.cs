using AutoMapper;
using CCM.GrpcProtos;

namespace CCM.Services.Mappers
{
    public class WorkerProfile : Profile
    {
        public WorkerProfile()
        {

            CreateMap<CCM.Domain.Entities.Persons.Worker, WorkerDTO>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.WorkerID, o => o.MapFrom(s => s.WorkerID))
                .ForMember(t => t.Job, o => o.MapFrom(s => s.Job))
                .ForMember(t => t.Salary, o => o.MapFrom(s => s.Salary));



            CreateMap<WorkerDTO, CCM.Domain.Entities.Persons.Worker>()
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id))
                .ForMember(t => t.WorkerID, o => o.MapFrom(s => s.WorkerID))
                .ForMember(t => t.Job, o => o.MapFrom(s => s.Job))
                .ForMember(t => t.Salary, o => o.MapFrom(s => s.Salary));
        }

    }
}