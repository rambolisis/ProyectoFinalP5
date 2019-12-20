using BoxManager.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxManager.DAL
{
    public class TipoConteoDAL : IGetAll<tipoConteo>
    {
        public List<tipoConteo> GetAll(int tenantId)
        {
            using (var entities = new BoxManagerEntities())
            {
                var tiposConteo = entities.tipoConteos.Where(t => t.idTenant == tenantId).ToList();
                return tiposConteo;
            }
        }
    }
}
