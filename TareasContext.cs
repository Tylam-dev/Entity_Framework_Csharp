using Microsoft.EntityFrameworkCore;
using Entity_Framework_Csharp;

namespace Entity_Framework_Csharp;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}
    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}
}