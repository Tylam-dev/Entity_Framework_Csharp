using Microsoft.EntityFrameworkCore;
using Entity_Framework_Csharp.Models;

namespace Entity_Framework_Csharp;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set}
    public Dbset<Tarea> Tareas {get;set}
    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}
}