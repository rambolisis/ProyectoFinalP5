using BoxManager.DO.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoxManager.DAL
{
    public class NivelDAL : IGetAll<nivel>
    {
        public List<nivel> GetAll(int tenantId)
        {
            using (var entities = new BoxManagerEntities())
            {
                var niveles = entities.nivels.Where(n => n.idTenant == tenantId).ToList();
                return niveles;
            }
        }
    }
}
