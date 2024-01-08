using AutoMapper;
using Bo.TodoAppNTİer.Bussines.Extensions;
using Bo.TodoAppNTİer.Bussines.İnterfaces;
using Bo.TodoAppNTİer.Bussines.ValidationRules;
using Bo.TodoAppNTİer.DataAccess.UnıtOfWork;
using Bo.TodoAppNTİer.Dtos.İnterfaces;
using Bo.TodoAppNTİer.Dtos.WorkDtos;
using Bo.TodoAppNTİer.Entities.Concrete;
using Bo.ToDoAppNTİer.Common.İnterface;
using Bo.ToDoAppNTİer.Common.ResponseObjects;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bo.TodoAppNTİer.Bussines.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> _createValidator;
        private readonly IValidator<WorkUpdateDto> _updateValidator;

        public WorkService(IUow uow, IMapper mapper = null, IValidator<WorkCreateDto> createValidator = null, IValidator<WorkUpdateDto> updateValidator = null)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            var validationResult = _createValidator.Validate(dto);            
            
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                _uow.Savechanges();
                return new Response<WorkCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                
               
                return new Response<WorkCreateDto>(ResponseType.ValidationError,dto,validationResult.ConvertToCustomValidationError());
            }
            
        }

        public async Task<IResponse<List<WorkListDto>>> GetAll()
        {
            var data = _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
            return new Response<List<WorkListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound,$"{id}ye ait data bulunamadı");
            }
           
           return new Response<IDto>(ResponseType.Success,data);
        }

       

        public async Task<IResponse> Remove(int id)
        {
            var removedEntity = await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);
            if (removedEntity != null)
            {
                _uow.GetRepository<Work>().Remove(removedEntity);
                await _uow.Savechanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id}ye ait data bulunamadı");
        }

        public async Task<IResponse<WorkUpdateDto>> Update(WorkUpdateDto dto)
        {

            var result = _updateValidator.Validate(dto);
            if (result.IsValid)
            {
                var updatedEntity = await _uow.GetRepository<Work>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto),updatedEntity);
                    await _uow.Savechanges();
                    return new Response<WorkUpdateDto>(ResponseType.Success,dto);
                }
                return new Response<WorkUpdateDto>(ResponseType.NotFound ,$"{dto.Id}ye ait data bulunamadı");
            }
            else
            {
               
                return new Response<WorkUpdateDto>(ResponseType.ValidationError,dto ,result.ConvertToCustomValidationError());
            } 

        }
    }
}
