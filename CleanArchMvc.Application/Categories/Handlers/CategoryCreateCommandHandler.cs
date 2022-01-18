﻿using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Categories.Handlers
{
    public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCreateCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);

            if (category == null)
                throw new ApplicationException($"Error creating entity .");

            return await _categoryRepository.CreateAsync(category);
        }
    }
}
