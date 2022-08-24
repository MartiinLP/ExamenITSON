using ExamenITSON.Models;
using ExamenITSON.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenITSON.Controllers
{
    public class AlumnosController : Controller
    {

        private readonly IAlumnoServicio _alumnoServicio;

        public AlumnosController(IAlumnoServicio alumnoServicio)
        {
            this._alumnoServicio = alumnoServicio;
        }
        public IActionResult Index()
        {
            try
            {
                var alumnos = _alumnoServicio.GetAlumnos();
                ViewBag.Alumnos = alumnos;
                return View("Alumnos");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
                string inner = (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(500, "Message ===> " + msg + " stack ===> " + stack + " ////// inner ===> " + inner);
            }

        }

        [HttpPost("CreateAlumno")]
        public IActionResult CreateAlumno(Alumnos alumno)
        {
            try
            {
                var result = _alumnoServicio.CreateAlumno(alumno);
                return Ok(result);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
                string inner = (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(500, "Message ===> " + msg + " stack ===> " + stack + " ////// inner ===> " + inner);
            }
        }

        [HttpDelete("RemoveAlumno")]
        public IActionResult RemoveAlumno(int Id)
        {
            try
            {
                var result = _alumnoServicio.RemoveAlumno(Id);               
                return Ok(result);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
                string inner = (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(500, "Message ===> " + msg + " stack ===> " + stack + " ////// inner ===> " + inner);
            }
        }

        [HttpPut("UpdateAlumno")]
        public IActionResult UpdateAlumno(Alumnos alumno)
        {
            try
            {
                var result = _alumnoServicio.UpdateAlumno(alumno);
                return Ok(result);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
                string inner = (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(500, "Message ===> " + msg + " stack ===> " + stack + " ////// inner ===> " + inner);
            }
        }

        [HttpGet("DetailsAlumno/{Id}")]
        public IActionResult DetailsAlumno(int Id)
        {
            try
            {
                var result = _alumnoServicio.DetailsAlumno(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
                string inner = (ex.InnerException == null ? "" : ex.InnerException.Message);
                return StatusCode(500, "Message ===> " + msg + " stack ===> " + stack + " ////// inner ===> " + inner);
            }
        }
    }
}
