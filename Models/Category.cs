namespace ToDo.Models;

public class Category
{
    //ID for db
    public long Id { get; set; }
    
    //Category's title
    public string Title { get; set; }
    
    //Optional, for parent category
    public long? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }

    //List of sub-categories, if this is a parent category
    public ICollection<Category>? Subcategories { get; set; } 
    
}