using AutoMapper;

namespace ToDo.Models;

public class ToDoResponseMapping: Profile
{
    public ToDoResponseMapping()
    {
        CreateMap<ToDoItem, ToDoResponse>();
    }
}