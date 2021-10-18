using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Bolsa_Empleados.Models;
using System.Web.Http;
using Bolsa_Empleados;

namespace Bolsa_Empleados.Controllers
{
    public class PosterController : ApiController
    {
        Bolsa_de_EmpleadosEntities1 db = new Bolsa_de_EmpleadosEntities1();
        public IHttpActionResult getPoster()
        {
           
            var resultado = db.DATOS_VACANTE.ToList();
            return Ok(resultado);
        }

        [HttpPost]
        public IHttpActionResult InsertarPoster(DATOS_VACANTE Poster)            
        {
            db.DATOS_VACANTE.Add(Poster);
            db.SaveChanges();
            return Ok();
        }

        
        public IHttpActionResult Put(Modelo_Datos_Vacantes poster)
        {
            var updatePoster = db.DATOS_VACANTE.Where(x => x.id == poster.id).FirstOrDefault();

            if (updatePoster!= null)
            {
                updatePoster.id = poster.id;
                updatePoster.Compañia = poster.Compañia;
                updatePoster.Tipo = poster.Tipo;
                updatePoster.Posicion = poster.Posicion;
                updatePoster.Ubicacion = poster.Ubicacion;
                updatePoster.Categoria = poster.Categoria;
                updatePoster.Descripcion_Trabajo = poster.Descripcion_Trabajo;
                updatePoster.Como_Aplicar = poster.Como_Aplicar;
                updatePoster.Email = poster.Email;
                db.SaveChanges();
            }

            else
            {
                return NotFound();
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var delPoster = db.DATOS_VACANTE.Where(x => x.id == id).FirstOrDefault();
            db.Entry(delPoster).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
