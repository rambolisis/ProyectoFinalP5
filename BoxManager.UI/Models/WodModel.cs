using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BoxManager.BS.Models
{
    public class WodModel
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public int IdNivel { get; set; }

        public string Nivel { get; set; }

        public int IdTipoConteo { get; set; }

        public string TipoConteo { get; set; }

        public int IdTenant { get; set; }

        public string ReturnUrl { get; set; }

        public List<SelectListItem> Niveles { get; set; }

        public List<SelectListItem> TiposConteo { get; set; }
    }
}
