using System;

namespace BoxManager.BS.DTO
{
    public class WodDTO
    {
        public int Id { get; set; }

        public  DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public int IdNivel { get; set; }

        public string Nivel { get; set; }

        public int IdTipoConteo { get; set; }

        public string TipoConteo { get; set; }

        public int IdCliente { get; set; }

        public string Cliente { get; set; }

        public int IdTenant { get; set; }
    }
}
