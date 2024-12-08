using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ToDo.Models;

namespace ToDo.Models;

public class ToDoContext : DbContext
{
    //DB Context for entity framework
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {
    }
    
    //For Creating ToDoItems table
    public DbSet<ToDoItem> ToDoItems { get; set; }
    
    //For Creating Categories table
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoItem>()
            .OwnsOne(t => t.Location);
    }
}