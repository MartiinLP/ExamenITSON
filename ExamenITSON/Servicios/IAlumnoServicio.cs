using ExamenITSON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenITSON.Servicios
{
   public interface IAlumnoServicio
    {
        List<Alumnos> GetAlumnos();
        bool CreateAlumno(Alumnos alumno);
        bool RemoveAlumno(int Id);
        bool UpdateAlumno(Alumnos alumno);
        Alumnos DetailsAlumno(int Id);
    }
}
