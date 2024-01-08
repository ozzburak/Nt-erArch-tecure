using AutoMapper;
using Bo.TodoAppNTİer.Dtos.WorkDtos;
using Bo.TodoAppNTİer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bo.TodoAppNTİer.Bussines.Mapping.AutoMapper
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkListDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work,WorkUpdateDto>().ReverseMap();
            CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();
        }
    }
}
