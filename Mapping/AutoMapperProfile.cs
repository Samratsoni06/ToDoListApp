using AutoMapper;
using ToDoListApp.Models;

namespace ToDoListApp.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskItem, CreateTaskDTO>().ReverseMap();
            CreateMap<TaskItem, UpdateTaskDTO>().ReverseMap();

        }
    }
}
