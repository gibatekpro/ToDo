namespace ToDo.Models;

//Author: Anthony Gibah
public class ExternalToDoItem
{
    //Author: Anthony Gibah
    public long Id { get; set; }
    public string Todo { get; set; }
    public bool Completed { get; set; }
    public long UserId { get; set; }
}