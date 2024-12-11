using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;

namespace ToDo.Services;

public interface IToDoService
{
    //Interface for fetching and storing todos
    public Task FetchAndStoreToDos();

    //Fetching ToDoList
    public Task<List<ToDoResponse>> FetchToDoList();
    
    //Fetching ToDoItem
    public Task<ToDoResponse> FetchToDoItem(long id);
    
    //Updating ToDoItem
    public Task UpdateToDoItem(long id, ToDoItem toDoItem);

    //Deleting ToDoItem
    public Task DeleteToDoItem(long id);
    
    //Posting Single ToDoItem
    public Task<ToDoResponse> PostToDoItem(ToDoItem toDoItem);
}