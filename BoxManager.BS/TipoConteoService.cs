using BoxManager.DAL;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BoxManager.BS
{
    public class TipoConteoService
    {
        public List<SelectListItem> GetByTenantId(int tenantIdId)
        {
            var tipoConteoDAL = new TipoConteoDAL();
            var tiposConteoEntities = tipoConteoDAL.GetAll(tenantIdId);

            var tiposConteo = new List<SelectListItem>();
            foreach (var tipoConteo in tiposConteoEntities)
            {
                tiposConteo.Add(new SelectListItem
                {
                    Value = tipoConteo.id.ToString(),
                    Text = tipoConteo.nombre
                });
            }

            return tiposConteo;
        }
    }
}
