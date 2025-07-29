using Application.TodoItems.Dtos;
using AutoMapper;
using Domain.Entities.TodoItem;

namespace UnitTestProject;
 public class TodoItemMappingProfile : Profile
{
    public TodoItemMappingProfile()
    {
        CreateMap<CreateTodoItemDto, TodoItem>();
        CreateMap<TodoItemDto, TodoItem>();
        CreateMap<TodoItem, TodoItemDto>();
    }
}