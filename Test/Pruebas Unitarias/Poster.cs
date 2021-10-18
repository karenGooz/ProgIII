using Bolsa_Empleados;
using Bolsa_Empleados.Controllers;
using Bolsa_Empleados.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace Test.Pruebas_Unitarias
{
    [TestClass]
    public class Poster
    {
        //Controlador API

        [TestMethod]
        public void getPoster()
        {
            PosterController control = new PosterController();
            IHttpActionResult v = control.getPoster() as IHttpActionResult;
        }

        [TestMethod]
        public void InsertarPoster()
        {
            PosterController control = new PosterController();
            DATOS_VACANTE p = new DATOS_VACANTE();
            p.Compañia = "Oficio";
            p.Tipo = "freelancer";
            p.Posicion = "Asistente";
            p.Ubicacion = "España";
            p.Categoria = "Programacion";
            p.Descripcion_Trabajo = "descripcion de trabajo";
            p.Como_Aplicar = "Trabaja duro";
            p.Email = "Joses@gmail.com";
            IHttpActionResult v = control.InsertarPoster(p) as IHttpActionResult;
        }

        [TestMethod]
        public void Put()
        {
            PosterController control = new PosterController();
            Modelo_Datos_Vacantes p = new Modelo_Datos_Vacantes();
            p.Compañia = "Oficio";
            p.Tipo = "freelancer";
            p.Posicion = "Asistente";
            p.Ubicacion = "España";
            p.Categoria = "Programacion";
            p.Descripcion_Trabajo = "descripcion de trabajo";
            p.Como_Aplicar = "Trabaja duro";
            p.Email = "Joses@gmail.com";
            IHttpActionResult v = control.Put(p) as IHttpActionResult;
        }

        [TestMethod]
        public void Delete()
        {
            PosterController control = new PosterController();
            int id = 114;

            IHttpActionResult v = control.Delete(id) as IHttpActionResult;
        }

        //Controlador MVC

        [TestMethod]
        public void Index2()
        {
            PosterMVCController control = new PosterMVCController();
            CATEGORIA cat = new CATEGORIA();
            cat.CATEGORIA1 = "Programacion";
            cat.id = 1;
            ViewResult v = control.Index2(cat) as ViewResult;
        }


        [TestMethod]
        public void Edit()
        {
            PosterMVCController control = new PosterMVCController();
            DATOS_VACANTE p = new DATOS_VACANTE();
            p.id = 113;
            p.Compañia = "Oficio";
            p.Tipo = "freelancer";
            p.Posicion = "Asistente";
            p.Ubicacion = "España";
            p.Categoria = "Programacion";
            p.Descripcion_Trabajo = "descripcion de trabajo";
            p.Como_Aplicar = "Trabaja duro";
            p.Email = "Joses@gmail.com";
            ViewResult v = control.Edit(p) as ViewResult;
        }

        [TestMethod]
        public void Editar()
        {
            PosterMVCController control = new PosterMVCController();
            DATOS_VACANTE p = new DATOS_VACANTE();
            p.id = 113;
            p.Compañia = "Oficio";
            p.Tipo = "freelancer";
            p.Posicion = "Asistente";
            p.Ubicacion = "España";
            p.Categoria = "Programacion";
            p.Descripcion_Trabajo = "descripcion de trabajo";
            p.Como_Aplicar = "Trabaja duro";
            p.Email = "Joses@gmail.com";
            ViewResult v = control.Edit(p) as ViewResult;
        }
    }
}
