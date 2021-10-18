using NHibernate.Mapping.ByCode.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bolsa_Empleados.Controllers
{
   
    public class AdministradorController : ApiController
    {



        Bolsa_de_EmpleadosEntities1 db = new Bolsa_de_EmpleadosEntities1();
        //public IHttpActionResult getAdministrador()
        //{
        //    var resultado = db.ADMINISTRADORs.ToList();
        //    return Ok(resultado);
        //}

        public IHttpActionResult getNumero_Vacantes()
        {
            var resultado = db.NUMERO_DE_PAGINACION.ToList();
            return Ok(resultado);
        }
    }
}
