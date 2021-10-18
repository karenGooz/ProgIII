using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bolsa_Empleados.Controllers
{
    public class LoginController : ApiController
    {
        Bolsa_de_EmpleadosEntities1 db = new Bolsa_de_EmpleadosEntities1();

        public IHttpActionResult getPoster()
        {

            var resultado = db.DATOS_VACANTE.ToList();
            return Ok(resultado);
        }

        [HttpPost]
        public IHttpActionResult InsertarPoster(POSTER Poster)
        {
            db.POSTERs.Add(Poster);
            db.SaveChanges();
            return Ok();
        }
    }
}
