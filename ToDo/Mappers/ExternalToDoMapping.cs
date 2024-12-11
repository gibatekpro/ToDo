using AutoMapper;
using ToDo.Models;

//Author: Anthony Gibah
namespace ToDo.Mappers;

public class ExternalToDoMapping: Profile
{
    //Author: Anthony Gibah
    public ExternalToDoMapping()
    {
        CreateMap<ExternalToDoItem, ToDoItem>()
            .ForMember(dest => dest.Todo, opt => opt.MapFrom(src => src.Todo))
            .ForMember(dest => dest.Completed, opt => opt.MapFrom(src => src.Completed))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => 3));
    }
}