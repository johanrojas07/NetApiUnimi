﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiEstudianteYMateria.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Uniminuto3CorteEntities : DbContext
    {
        public Uniminuto3CorteEntities()
            : base("name=Uniminuto3CorteEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Estudiantes_Materias> Estudiantes_Materias { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
    }
}
