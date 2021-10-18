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
    public class Login
    {
        //Controlador API
        [TestMethod]
        public void getPoster()
        {
            LoginController control = new LoginController();
            IHttpActionResult v = control.getPoster() as IHttpActionResult;
        }

        [TestMethod]
        public void InsertarPoster()
        {
            LoginController control = new LoginController();
            POSTER p = new POSTER();
            p.Contraseña_Poster = "12345";
            p.Correo_Poster = "joses@gmail.com";
            p.Nombre_de_Compañia = "Joses";

            IHttpActionResult v = control.InsertarPoster(p) as IHttpActionResult;
        }


        //Controlador MVC
        [TestMethod]
        public void Index()
        {
            LoginMVCController control = new LoginMVCController();
            string mensaje = "Hola";
            ViewResult prueba = control.Index(mensaje) as ViewResult;
        }      

        [TestMethod]
        public void Create()
        {
            LoginMVCController control = new LoginMVCController();
            string mensaje = "Hola";
            ViewResult prueba = control.Create(mensaje) as ViewResult;
        }

        [TestMethod]
        public void CreatePost()
        {
            LoginMVCController control = new LoginMVCController();
            string Nombre_de_Compañia = "Tecnologia";
                string Correo_Poster = "H@gmail.com";
            string Contraseña_Poster = "1234";
            string repetir = "1234";
            ViewResult prueba = control.Create(Nombre_de_Compañia,Correo_Poster,Contraseña_Poster,repetir) as ViewResult;
        }



    }
}
