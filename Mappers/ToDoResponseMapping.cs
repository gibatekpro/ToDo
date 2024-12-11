using AutoMapper;

//Author: Anthony Gibah
namespace ToDo.Models;

//Author: Anthony Gibah
public class ToDoResponseMapping: Profile
{
    public ToDoResponseMapping()
    {
        //Author: Anthony Gibah
        CreateMap<ToDoItem, ToDoResponse>();
    }
}