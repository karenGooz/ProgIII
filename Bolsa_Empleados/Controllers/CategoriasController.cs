using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bolsa_Empleados.Models;

namespace Bolsa_Empleados.Controllers
{
    public class CategoriasController : ApiController
    {
        Bolsa_de_EmpleadosEntities1 db = new Bolsa_de_EmpleadosEntities1();

        public IHttpActionResult getPoster()
        {

            var resultado = db.CATEGORIAS.ToList();
            return Ok(resultado);
        }

        [HttpPost]
        public IHttpActionResult InsertarCategoria(CATEGORIA Poster)
        {
            db.CATEGORIAS.Add(Poster);
            db.SaveChanges();
            return Ok();
        }


        public IHttpActionResult Put(Model_Categorias categoria)
        {
            var updatePoster = db.CATEGORIAS.Where(x => x.id == categoria.id).FirstOrDefault();

            if (updatePoster != null)
            {
                updatePoster.id = categoria.id;
                updatePoster.CATEGORIA1 = categoria.CATEGORIA1;               
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
            var delPoster = db.CATEGORIAS.Where(x => x.id == id).FirstOrDefault();
            db.Entry(delPoster).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
