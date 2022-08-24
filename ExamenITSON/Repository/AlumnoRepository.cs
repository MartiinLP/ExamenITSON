using ExamenITSON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenITSON.Repository
{
    public class AlumnoRepository:IAlumnoRepository
    {
        private dbExamenContext _context;

        public AlumnoRepository(dbExamenContext context)
        {
            this._context = context;
        }

        public bool CreateAlumno(Alumnos alumno)
        {
            _context.Alumnos.Add(alumno);
            _context.SaveChanges();
            return true;
        }

        public Alumnos DetailsAlumno(int Id)
        {
            var alumno = _context.Alumnos.Where(x => x.Id == Id).First();
            return alumno;
        }

        public List<Alumnos> GetAlumnos()
        {
            var Listalumnos = _context.Alumnos.ToList();
            return Listalumnos;
        }

        public bool RemoveAlumno(int Id)
        {
            var alumno = _context.Alumnos.Where(x => x.Id == Id).First();
            _context.Alumnos.Remove(alumno);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateAlumno(Alumnos alumno)
        {
            var _alumno = _context.Alumnos.Where(x => x.Id == alumno.Id).First();
            _context.Alumnos.Attach(_alumno);
            _alumno.Nombres = alumno.Nombres;
            _alumno.ApellidoPaterno = alumno.ApellidoPaterno;
            _alumno.ApellidoMaterno = alumno.ApellidoMaterno;
            _alumno.EstaActivo = alumno.EstaActivo;
            _context.SaveChanges();
            return true;
        }
    }
}
