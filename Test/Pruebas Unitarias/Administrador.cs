using Bolsa_Empleados;
using Bolsa_Empleados.Controllers;
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
    public class Administrador
    {       
        //Controlador MVC
       [TestMethod]
        public void  Index()
        {
            AdministradorMVCController control = new AdministradorMVCController();
            string mensaje = "Hola";
            ViewResult prueba = control.Index(mensaje) as ViewResult;
                     
        }

        [TestMethod]
        public void IndexPost()
        {
            AdministradorMVCController control = new AdministradorMVCController();
            string Correo_Administrador = "benjamin@gmail.com", Contraseña_Administrador = "3123123434";
            ViewResult benja = control.Index(Correo_Administrador, Contraseña_Administrador) as ViewResult;
        }

        //Controlador API
        [TestMethod]
        public void get()
        {
            AdministradorController control = new AdministradorController();
            IHttpActionResult v = control.getNumero_Vacantes() as IHttpActionResult;
        }
    }
}
