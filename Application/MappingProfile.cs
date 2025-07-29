using Application.TodoItems.Dtos;
using AutoMapper;
using Domain.Entities.TodoItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTodoItemDto, TodoItem>()
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<TodoItem, TodoItemDto>()
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<TodoItemDto, TodoItem>()
              .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
