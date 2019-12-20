using BoxManager.DAL;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BoxManager.BS
{
    public class NivelService
    {
        public List<SelectListItem> GetByTenantId(int tenantIdId)
        {
            var nivelesDAL = new NivelDAL();
            var nivelesEntities = nivelesDAL.GetAll(tenantIdId);

            var niveles = new List<SelectListItem>();
            foreach(var nivel in nivelesEntities)
            {
                niveles.Add(new SelectListItem
                {
                    Value = nivel.id.ToString(),
                    Text = nivel.nombre
                });
            }

            return niveles;
        }
    }
}
