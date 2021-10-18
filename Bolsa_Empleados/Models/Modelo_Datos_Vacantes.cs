using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bolsa_Empleados.Models
{
    public class Modelo_Datos_Vacantes
    {
        public int id { get; set; }
        public string Compañia { get; set; }
        public string Tipo { get; set; }
        public string Posicion { get; set; }
        public string Ubicacion { get; set; }
        public string Categoria { get; set; }
        public string Descripcion_Trabajo { get; set; }
        public string Como_Aplicar { get; set; }
        public string Email { get; set; }
    }
}