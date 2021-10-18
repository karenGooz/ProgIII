using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Bolsa_Empleados.Controllers
{
   
    public class AdministradorMVCController : Controller
    {
        Bolsa_de_EmpleadosEntities1 db = new Bolsa_de_EmpleadosEntities1();

        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Correo_Administrador, string Contraseña_Administrador)
        {

            if (!string.IsNullOrEmpty(Correo_Administrador) && !string.IsNullOrEmpty(Contraseña_Administrador))
            {
                var user =  db.ADMINISTRADORs.FirstOrDefault(a => a.Correo_Administrador == Correo_Administrador && a.Contraseña_Administrador == Contraseña_Administrador);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Correo_Administrador, true);
                    return RedirectToAction("Index", "PosterMVC");
                }
                else
                {
                    return RedirectToAction("Index", new { message = "No encontramos tus datos" });
                }
            }
            else
            {
                return RedirectToAction("Index", new { message = "Llena los campos vacios para poder iniciar sesion" });
            }
        }

        public ActionResult IndexNumero_paginacion()
        {
            IEnumerable<NUMERO_DE_PAGINACION> numero = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44343/api/Administrador");
            var consumirApi = hc.GetAsync("Administrador");
            consumirApi.Wait();
            var readdata = consumirApi.Result;

            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<NUMERO_DE_PAGINACION>>();
                displaydata.Wait();

                numero = displaydata.Result;
            }

            return View(numero);
        }

        public ActionResult Edit(int? id)
        {         
            NUMERO_DE_PAGINACION NUMERO = db.NUMERO_DE_PAGINACION.Find(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (NUMERO == null)
            {
                return HttpNotFound();
            }
            return View(NUMERO);
        }

        // POST: Poster/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Numero_de_Paginas")] NUMERO_DE_PAGINACION NUMERO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(NUMERO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexNumero_paginacion");
            }
            return View(NUMERO);
        }


        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "PosterMVC");
        }
    }
}