using ToDo.Models;

namespace ToDo.Repos;

public interface IToDoRepo
{
    //IMethod for saving list to db
    Task SaveToDoList(List<ToDoItem> todos);
    
    //Fetch ToDoList
    Task<List<ToDoItem>> FetchToDoList();
    
    //Fetch ToDoItem
    Task<ToDoItem> FetchToDoItem(long id);

    //Update ToDos Item
    public Task UpdateToDoItem(long id, ToDoItem toDoItem);
    
    //Deleting TodoItems
    public Task DeleteToDoItem(ToDoItem toDoItem);
    
    //To Know if item exists
    public Task<ToDoItem?> GetToDoItemById(long id);
    
    //Post Single ToDoItem
    public Task PostToDoItem(ToDoItem toDoItem);
}