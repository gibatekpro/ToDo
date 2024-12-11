namespace ToDo.Models;

public class ExternalToDoItem
{
    public long Id { get; set; }
    public string Todo { get; set; }
    public bool Completed { get; set; }
    public long UserId { get; set; }
}