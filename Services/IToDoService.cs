using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;

namespace ToDo.Services;

//Author: Anthony Gibah
public interface IToDoService
{
    //Interface for fetching and storing todos
    public Task FetchAndStoreToDos();

    //Fetching ToDoList
    public Task<List<ToDoResponse>> FetchToDoList();
    
    //Author: Anthony Gibah
    //Fetching ToDoItem
    public Task<ToDoResponse> FetchToDoItem(long id);
    
    //Updating ToDoItem
    public Task UpdateToDoItem(long id, ToDoItem toDoItem);

    //Author: Anthony Gibah
    //Deleting ToDoItem
    public Task DeleteToDoItem(long id);
    
    //Posting Single ToDoItem
    public Task<ToDoResponse> PostToDoItem(ToDoItem toDoItem);
    
    //Author: Anthony Gibah
    //Search by title or by priority or by dueDate
    public Task<IEnumerable<ToDoResponse>> SearchToDoItems(string? title, int? priority, DateTime? dueDate);
}