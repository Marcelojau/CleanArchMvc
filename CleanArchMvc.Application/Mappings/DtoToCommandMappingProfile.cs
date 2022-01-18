using AutoMapper;
using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Mappings
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();

            CreateMap<CategoryDto, CategoryCreateCommand>();
            CreateMap<CategoryDto, CategoryUpdateCommand>();
        }
    }
}
