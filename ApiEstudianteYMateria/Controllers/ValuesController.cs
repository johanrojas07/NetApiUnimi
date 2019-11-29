using ApiEstudianteYMateria.Dtos;
using ApiEstudianteYMateria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiEstudianteYMateria.Controllers
{
    public class ValuesController : ApiController
    {

        
        [HttpPost]
        public bool addSubjectWithStudent([FromBody] registry value)
        {
            using (var db = new Uniminuto3CorteEntities())
            {
                Estudiantes_Materias es = new Estudiantes_Materias();
                es.nrc = value.nrc;
                es.codigo = value.codigo;
                db.Estudiantes_Materias.Add(es);
                db.SaveChanges();
                return true;
            }
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<bool> deleteSubjectWithStudentAsync([FromBody] registry value)
        {
            using (var db = new Uniminuto3CorteEntities())
            {
                db.Estudiantes_Materias.RemoveRange(db.Estudiantes_Materias.Where(x => x.nrc == value.nrc && x.codigo == value.codigo));
                db.SaveChanges();
                return true;
            }
        }

        [HttpPost]
        public bool deleteSubject([FromBody] registry value)
        {
            using (var db = new Uniminuto3CorteEntities())
            {
                db.Estudiantes_Materias.RemoveRange(db.Estudiantes_Materias.Where(x => x.nrc == value.nrc));
                db.Materia.RemoveRange(db.Materia.Where(x => x.nrc == value.nrc));
                db.SaveChanges();
                return true;
            }
        }

        [HttpPost]
        public bool deleteStudent([FromBody] registry value)
        {
            using (var db = new Uniminuto3CorteEntities())
            {
                db.Estudiantes_Materias.RemoveRange(db.Estudiantes_Materias.Where(x => x.codigo == value.codigo));
                db.Estudiante.RemoveRange(db.Estudiante.Where(x => x.codigo == value.codigo));
                db.SaveChanges();
                return true;
            }
        }


        [HttpGet]
        public object GetStudents()
        {
            using (var db = new Uniminuto3CorteEntities())
            {
                
                var students = db.Estudiante.ToList();
                return students;
            }
        }
 
        [HttpPost]
        public int createStudent([FromBody]EstudianteDTO value)
        {
            using (var db = new Uniminuto3CorteEntities())
            {
                Estudiante es = new Estudiante();
                es.codigo = value.codigo;
                es.nombre = value.nombre;
                db.Estudiante.Add(es);
                db.SaveChanges();
                return value.codigo;
            }
        }

        [HttpPost]
        public int createSubject([FromBody]MateriaDTO value)
        {
            using (var db = new Uniminuto3CorteEntities())
            {
                Materia ma = new Materia();
                ma.nrc = value.nrc;
                ma.descripcion = value.description;
                ma.hashkey = value.hashkey;
                db.Materia.Add(ma);
                db.SaveChanges();
                return value.nrc;
            }
        }

        [HttpPost]
        public object studentsInSubject([FromBody]int nrcSubject)
        {
            using (var db = new Uniminuto3CorteEntities())
            {
                var students = (from es in db.Estudiante
                                join ma in db.Estudiantes_Materias on es.codigo equals ma.codigo
                                where ma.nrc == nrcSubject
                                select new
                                {
                                    es.codigo,
                                    es.nombre,
                                    ma.ID
                                }).ToList();
                return students;
            }
        }

    }

    public class registry
    {
        public int codigo { get; set; }
        public int nrc { get; set; }
    }

    public class delete
    {
        public int ID { get; set; }
    }



}

