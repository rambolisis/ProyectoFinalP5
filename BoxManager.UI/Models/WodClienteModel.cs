using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BoxManager.BS.Models
{
    public class WodClienteModel
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public int IdCliente { get; set; }

        public string Cliente { get; set; }

        public int IdTipoConteo { get; set; }

        public string TipoConteo { get; set; }

        public int IdTenant { get; set; }

        public string ReturnUrl { get; set; }

        public List<SelectListItem> Clientes { get; set; }

        public List<SelectListItem> TiposConteo { get; set; }
    }
}
