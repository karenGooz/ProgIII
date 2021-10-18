using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bolsa_Empleados.Models;
using System.Net.Http;
using System.Net;
using System.Data.Entity;

namespace Bolsa_Empleados.Controllers
{
    public class PosterMVCController : Controller
    {
        Bolsa_de_EmpleadosEntities1 db = new Bolsa_de_EmpleadosEntities1();

        // GET: PosterMVC
        public ActionResult Index()
        {
            IEnumerable<DATOS_VACANTE> poster = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44343/api/Poster");
            var consumirApi = hc.GetAsync("Poster");
            consumirApi.Wait();
            var readdata = consumirApi.Result;

            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<DATOS_VACANTE>>();
                displaydata.Wait();

                poster = displaydata.Result;
            }

            return View(poster);
        }


        public ActionResult Index2([Bind(Include = "id,CATEGORIA1")] CATEGORIA CATEGORIA)
        {
           
            var categoria = db.CATEGORIAS.Where(x => x.id == CATEGORIA.id).ToList();

            var datos = new List<DATOS_VACANTE>();
            foreach (var item in categoria)
            {
                datos = db.DATOS_VACANTE.Where(x => x.Categoria == item.CATEGORIA1).ToList();
            }

            foreach (var item in categoria)
            {
                ViewBag.categoria = item.CATEGORIA1;
            }

            datos.Reverse();
            return View(datos);
        }

        public ActionResult IndexCrud()
        {
            IEnumerable<DATOS_VACANTE> poster = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44343/api/Poster");
            var consumirApi = hc.GetAsync("Poster");
            consumirApi.Wait();
            var readdata = consumirApi.Result;

            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<DATOS_VACANTE>>();
                displaydata.Wait();

                poster = displaydata.Result;
            }

            return View(poster);
        }


        public ActionResult Create()
        {
            ViewBag.items = db.CATEGORIAS.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DATOS_VACANTE Poster)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44343/api/Poster");
            var InsertarPosster = hc.PostAsJsonAsync<DATOS_VACANTE>("Poster",Poster);
            InsertarPosster.Wait();

            var savedata = InsertarPosster.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("IndexCrud");
            }
            return View("Create");
        }


        public ActionResult Edit(int? id)
        {
            ViewBag.items = db.CATEGORIAS.ToList();
            DATOS_VACANTE VACANTE = db.DATOS_VACANTE.Find(id);         

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (VACANTE == null)
            {
                return HttpNotFound();
            }
            return View(VACANTE);
        }

        // POST: Poster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Compañia,Tipo,Posicion,Ubicacion,Categoria,Descripcion_Trabajo,Como_Aplicar,Email")] DATOS_VACANTE VACANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(VACANTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexCrud");
            }
            return View(VACANTE);
        }


        public ActionResult Editar(int? id)
        {
            ViewBag.items = db.CATEGORIAS.ToList();
            DATOS_VACANTE VACANTE = db.DATOS_VACANTE.Find(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (VACANTE == null)
            {
                return HttpNotFound();
            }
            return View(VACANTE);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "id,Compañia,Tipo,Posicion,Ubicacion,Categoria,Descripcion_Trabajo,Como_Aplicar,Email")] DATOS_VACANTE VACANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(VACANTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(VACANTE);
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44343/api/Poster");

            var delrecord = hc.DeleteAsync("Poster/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if (displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("IndexCrud");
            }

            return View("IndexCrud");
        }

        public ActionResult Borrar(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44343/api/Poster");

            var delrecord = hc.DeleteAsync("Poster/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if (displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}