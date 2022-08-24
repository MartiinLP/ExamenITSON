using ExamenITSON.Models;
using ExamenITSON.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenITSON.Servicios
{
    public class AlumnoServicio:IAlumnoServicio
    {
        private readonly IAlumnoRepository _alumnoRepository;

        public AlumnoServicio(IAlumnoRepository alumnoRepository)
        {
            this._alumnoRepository = alumnoRepository;
        }

        public bool CreateAlumno(Alumnos alumno)
        {
            bool result = _alumnoRepository.CreateAlumno(alumno);
            return true;
        }

        public Alumnos DetailsAlumno(int Id)
        {
            Alumnos alumno = _alumnoRepository.DetailsAlumno(Id);
            return alumno;
        }

        public List<Alumnos> GetAlumnos()
        {
            List<Alumnos> alumnos = _alumnoRepository.GetAlumnos();
            return alumnos;
        }

        public bool RemoveAlumno(int Id)
        {
            bool result = _alumnoRepository.RemoveAlumno(Id);
            return true;
        }

        public bool UpdateAlumno(Alumnos alumno)
        {
            bool result = _alumnoRepository.UpdateAlumno(alumno);
            return true;
        }
    }
}
