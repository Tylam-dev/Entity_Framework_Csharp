using Entity_Framework_Csharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDb"));
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("tarea-db"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria" + dbContext.Database.IsInMemory());
});
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) => 
{
    return Results.Ok(dbContext.Tareas);
});
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) => 
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.UtcNow;
    await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) => 
{
    var tareaActual = dbContext.Tareas.Find(id);
    if(tareaActual != null)
    {
        tareaActual.Titulo = tarea.Titulo?? tareaActual.Titulo;
        tareaActual.Descripcion = tarea.Descripcion ?? tareaActual.Descripcion;
        // You can not use terceary conditional with a no nullable enum
        // tareaActual.PrioridadTarea = tarea.PrioridadTarea.HasValue ? tareaActual.PrioridadTarea = tarea.PrioridadTarea : tareaActual.PrioridadTarea = tareaActual.PrioridadTarea;

        await dbContext.SaveChangesAsync();
        
        return Results.Ok();
    }
    return Results.NotFound();
});

app.Run();