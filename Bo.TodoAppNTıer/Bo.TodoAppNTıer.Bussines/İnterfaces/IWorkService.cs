using Bo.TodoAppNTİer.Dtos.İnterfaces;
using Bo.TodoAppNTİer.Dtos.WorkDtos;
using Bo.ToDoAppNTİer.Common.İnterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bo.TodoAppNTİer.Bussines.İnterfaces
{
    public interface IWorkService
    {
        Task<IResponse<List<WorkListDto>>> GetAll();
        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto);
        Task<IResponse< IDto>> GetById<IDto>(int id);

        Task<IResponse> Remove(int id);
        Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto);
    }
}
