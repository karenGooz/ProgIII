using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bolsa_Empleados.Models
{
    public class Poster
    {
        public int id { get; set; }
        public string Correo_Poster { get; set; }
        public string Contraseña_Poster { get; set; }
        public string Nombre_de_Compañia { get; set; }
    }
}