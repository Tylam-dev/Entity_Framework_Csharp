﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entity_Framework_Csharp;

public class Categoria
{
    // [Key]
    public Guid CategoriaId {get;set;}

    // [Required]
    // [MaxLength(150)]
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    public int Peso {get;set;}
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;}
}
