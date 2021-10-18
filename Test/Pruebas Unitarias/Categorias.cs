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
    public class Categorias
    {


        //Controlador API

        [TestMethod]
        public void getCategoria()
        {
            CategoriasController control = new CategoriasController();
            IHttpActionResult v = control.getPoster() as IHttpActionResult;
        }

        [TestMethod]
        public void InsertarCategoria()
        {
            CategoriasController control = new CategoriasController();
            CATEGORIA cat = new CATEGORIA();
            cat.CATEGORIA1 = "Hola";

            IHttpActionResult v = control.InsertarCategoria(cat) as IHttpActionResult;
        }

        [TestMethod]
        public void Put()
        {
            CategoriasController control = new CategoriasController();
            Model_Categorias cat = new Model_Categorias();

            cat.CATEGORIA1 = "Hola2";
            cat.id = 21;

            IHttpActionResult v = control.Put(cat) as IHttpActionResult;
        }

        [TestMethod]
        public void Delete()
        {
            CategoriasController control = new CategoriasController();
            int id = 25;

            IHttpActionResult v = control.Delete(id) as IHttpActionResult;
        }


        //Controlador MVC

        [TestMethod]
        public void Edit()
        {
            CategoriaMVCController control = new CategoriaMVCController();
            CATEGORIA cat = new CATEGORIA();
            cat.CATEGORIA1 = "holiss";
            cat.id = 20;
            ViewResult v = control.Edit(cat) as ViewResult;

        }
     

    }
}
