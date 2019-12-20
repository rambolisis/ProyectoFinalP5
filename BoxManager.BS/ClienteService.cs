using BoxManager.DAL;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BoxManager.BS
{
    public class ClienteService
    {
        public List<SelectListItem> GetByTenantId(int tenantIdId)
        {
            var clientessDAL = new ClienteDAL();
            var clientesEntities = clientessDAL.GetAll(tenantIdId);

            var clientes = new List<SelectListItem>();
            foreach (var cliente in clientesEntities)
            {
                clientes.Add(new SelectListItem
                {
                    Value = cliente.id.ToString(),
                    Text = cliente.nombre
                });
            }

            return clientes;
        }
    }
}
