using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bolsa_Empleados.Models
{
    public class Model_Administrador
    {
        public int id { get; set; }
        public string Correo_Administrador { get; set; }
        public string Contraseña_Administrador { get; set; }
    }
}