using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Bolsa_Empleados.Models;

namespace Bolsa_Empleados.Controllers
{
    public class CategoriaMVCController : Controller
    {
        Bolsa_de_EmpleadosEntities1 db = new Bolsa_de_EmpleadosEntities1();

        // GET: CategoriaMVC
        public ActionResult Index()
        {
            IEnumerable<CATEGORIA> categoria = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44343/api/Categorias");
            var consumirApi = hc.GetAsync("Categorias");
            consumirApi.Wait();
            var readdata = consumirApi.Result;

            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<CATEGORIA>>();
                displaydata.Wait();

                categoria = displaydata.Result;
            }

            return View(categoria);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CATEGORIA categoria)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44343/api/Categorias");
            var InsertarPosster = hc.PostAsJsonAsync<CATEGORIA>("Categorias", categoria);
            InsertarPosster.Wait();

            var savedata = InsertarPosster.Result;
            if (savedata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Edit(int? id)
        {
            CATEGORIA CATEGORIA = db.CATEGORIAS.Find(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (CATEGORIA == null)
            {
                return HttpNotFound();
            }
            return View(CATEGORIA);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CATEGORIA1")] CATEGORIA CATEGORIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(CATEGORIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CATEGORIA);
        }



        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44343/api/Categorias");

            var delrecord = hc.DeleteAsync("Categorias/" + id.ToString());
            delrecord.Wait();

            var displaydata = delrecord.Result;
            if (displaydata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("IndexCrud");
        }

    }
}