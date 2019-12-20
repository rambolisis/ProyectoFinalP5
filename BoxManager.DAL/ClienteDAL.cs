using BoxManager.DO.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoxManager.DAL
{
    public class ClienteDAL :  IGetAll<cliente>
    {
        public List<cliente> GetAll(int tenantId)
        {
            using (var entities = new BoxManagerEntities())
            {
                var clientes = entities.clientes.Where(t => t.idTenant == tenantId).ToList();
                return clientes;
            }
        }
    }
}
