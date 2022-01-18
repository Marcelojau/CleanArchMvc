using AutoMapper;
using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Application.Categories.Queries;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CategoryService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<CategoryDto> GetById(int? id)
        {

            var categoriyByIdQuery = new GetCategoryByIdQuery(id.Value);

            if (categoriyByIdQuery == null)
                throw new ApplicationException($"Entity could not be loaded. ");

            var result = await _mediator.Send(categoriyByIdQuery);

            return _mapper.Map<CategoryDto>(result);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesQuery = new GetCategoriesQuery();

            if (categoriesQuery == null)
                throw new ApplicationException($"Entity could not be loaded. ");

            var result = await _mediator.Send(categoriesQuery);

            return _mapper.Map<IEnumerable<CategoryDto>>(result);
        }

        public async Task Add(CategoryDto categoryDto)
        {
            var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDto);

            if (categoryCreateCommand == null)
                throw new ApplicationException($"Entity could not be loaded. ");

            await _mediator.Send(categoryCreateCommand);

        }

        public async Task Remove(int? id)
        {
            var categoryRemoveCommand = new CategoryRemoveCommand(id.Value);

            if (categoryRemoveCommand == null)
                throw new ApplicationException($"Entity could not be loaded. ");

            await _mediator.Send(categoryRemoveCommand);

        }

        public async Task Update(CategoryDto categoryDto)
        {
            var categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(categoryDto);

            if (categoryUpdateCommand == null)
                throw new ApplicationException($"Entity could not be loaded. ");

            await _mediator.Send(categoryUpdateCommand);

        }
    }
}
