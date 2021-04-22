namespace Escuela.Clases
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alumnos")]
    public partial class Alumno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAlumno { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(45)]
        public string Nacimiento { get; set; }

        public int IdCurso { get; set; }

        public virtual Curso Curso { get; set; }
    }
}
