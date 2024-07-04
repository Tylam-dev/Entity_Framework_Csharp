namespace Entity_Framework_Csharp;

public class categoria
{
    public Guid categoriaId {get;set};
    public string Nombre {get;set};
    public string Descripcion {get;set};
    public virtual ICollection<Tarea> Tareas {get;set};
}
