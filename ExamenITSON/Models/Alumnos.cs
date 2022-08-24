using System;
using System.Collections.Generic;

namespace ExamenITSON.Models
{
    public partial class Alumnos
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public bool? EstaActivo { get; set; }
    }
}
