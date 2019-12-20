using System.Collections.Generic;
using System.Linq;
using BoxManager.BS.DTO;
using BoxManager.DAL;

namespace BoxManager.BS
{
    public class WodService
    {
        public void Save(WodDTO wodDto)
        {
            var wodDAL = new WodDAL();

            var wod = new wod()
            {
                id = wodDto.Id,
                fecha = wodDto.Fecha,
                nivel = wodDto.IdNivel,
                descripcion = wodDto.Descripcion,
                tipoConteo = wodDto.IdTipoConteo,
                idTenant = wodDto.IdTenant
            };

            if (wod.id == 0)
            {
                wodDAL.Insert(wod);
            }
            else
            {
                wodDAL.Update(wod);
            }
        }

        public WodDTO GetById(int wodId)
        {
            var wodDAL = new WodDAL();
            var dbWods = wodDAL.Get(wodId);
            var wodDto = new WodDTO()
            {
                Id = dbWods.id,
                Descripcion = dbWods.descripcion,
                Fecha = dbWods.fecha.Value,
                IdNivel = dbWods.nivel.Value,
                IdTipoConteo = dbWods.tipoConteo.Value,
                IdTenant = dbWods.idTenant
            };

            return wodDto;
        }

        public List<WodDTO> GetByTenantId(int tenantId)
        {
            var wodDAL = new WodDAL();
            var dbWods = wodDAL.GetAll(tenantId);

            var wods = dbWods.Select(w => new WodDTO
            {
                Id = w.id,
                Descripcion = w.descripcion,
                Fecha = w.fecha.Value,
                Nivel = w.nivel1.nombre,
                TipoConteo = w.tipoConteo1.nombre
            }).ToList();

            return wods;
        }

        public void Delete(int wodId)
        {
            var wodDAL = new WodDAL();
            wodDAL.Delete(wodId);
        }
    }
}
