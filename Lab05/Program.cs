using Lab05.Models;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Configure JSON options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

var app = builder.Build();

// In-memory database
var todoItems = new List<TodoItem>
{
    new TodoItem { Id = 1, Name = "Walk the dog", IsComplete = false, Secret = "Secret1" },
    new TodoItem { Id = 2, Name = "Buy groceries", IsComplete = true, Secret = "Secret2" },
    new TodoItem { Id = 3, Name = "Finish homework", IsComplete = false, Secret = "Secret3" }
};

// GET /todoitems - Get all todo items
app.MapGet("/todoitems", () => 
    Results.Ok(todoItems.Select(x => new TodoItemDTO 
    { 
        Id = x.Id, 
        Name = x.Name, 
        IsComplete = x.IsComplete 
    })));

// GET /todoitems/{id} - Get a specific todo item by ID
app.MapGet("/todoitems/{id}", (int id) =>
{
    var todo = todoItems.FirstOrDefault(x => x.Id == id);
    return todo == null 
        ? Results.NotFound() 
        : Results.Ok(new TodoItemDTO 
        { 
            Id = todo.Id, 
            Name = todo.Name, 
            IsComplete = todo.IsComplete 
        });
});

// POST /todoitems - Create a new todo item
app.MapPost("/todoitems", (TodoItemDTO todoItemDTO) =>
{
    var todoItem = new TodoItem
    {
        Id = todoItems.Count > 0 ? todoItems.Max(x => x.Id) + 1 : 1,
        Name = todoItemDTO.Name,
        IsComplete = todoItemDTO.IsComplete,
        Secret = $"Secret{todoItemDTO.Id}"
    };
    
    todoItems.Add(todoItem);
    
    return Results.Created($"/todoitems/{todoItem.Id}", new TodoItemDTO
    {
        Id = todoItem.Id,
        Name = todoItem.Name,
        IsComplete = todoItem.IsComplete
    });
});

// PUT /todoitems/{id} - Update an existing todo item
app.MapPut("/todoitems/{id}", (int id, TodoItemDTO todoItemDTO) =>
{
    var todo = todoItems.FirstOrDefault(x => x.Id == id);
    
    if (todo == null)
        return Results.NotFound();
    
    todo.Name = todoItemDTO.Name;
    todo.IsComplete = todoItemDTO.IsComplete;
    
    return Results.NoContent();
});

// DELETE /todoitems/{id} - Delete a todo item
app.MapDelete("/todoitems/{id}", (int id) =>
{
    var todo = todoItems.FirstOrDefault(x => x.Id == id);
    
    if (todo == null)
        return Results.NotFound();
    
    todoItems.Remove(todo);
    
    return Results.NoContent();
});

app.Run();
