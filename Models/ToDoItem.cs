
namespace ToDo.Models;

public class ToDoItem
{
    //Foreign Key property
    public long Id { get; set; }
    
    //Todos item's name
    public string Todo { get; set; }
    
    //Completed (true or false)
    public bool Completed { get; set; }
    
    //Id of user
    public long UserId { get; set; }
    
    //Category this todos item belongs to
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    
    //Priority of item. Default set to 3
    public int Priority { get; set; } = 3;
    public LocationItem? Location { get; set; }
    
    //Due date of item
    public DateTime? DueDate { get; set; }
}