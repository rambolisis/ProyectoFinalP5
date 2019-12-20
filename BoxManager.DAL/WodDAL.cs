using BoxManager.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoxManager.DAL
{
    public class WodDAL : ICRUD<wod>, IGetAll<wod>
    {
        public void Delete(int wodId)
        {
            using (var entities = new BoxManagerEntities())
            {
                var wod = entities.wods.FirstOrDefault(w => w.id == wodId);
                if (wod != null)
                {
                    entities.wods.Remove(wod);
                    entities.SaveChanges();
                }
            }
        }

        public wod Get(int wodId)
        {
            using (var entities = new BoxManagerEntities())
            {
                var wod = entities.wods.FirstOrDefault(w => w.id == wodId);
                return wod;
            }
        }

        public List<wod> GetAll(int tenantId)
        {
            using (var entities = new BoxManagerEntities())
            {
                var wods = entities.wods.Where(w => w.idTenant == tenantId)
                    .Include("nivel1")
                    .Include("tipoConteo1")
                    .ToList();
                return wods;
            }
        }

        public void Insert(wod entity)
        {
            using (var entities = new BoxManagerEntities())
            {
                entities.wods.Add(entity);
                entities.SaveChanges();
            }
        }

        public void Update(wod entity)
        {
            using (var entities = new BoxManagerEntities())
            {
                var wod = entities.wods.FirstOrDefault(w => w.id == entity.id);
                if (wod != null)
                {
                    wod.descripcion = entity.descripcion;
                    wod.fecha = entity.fecha;
                    wod.nivel = entity.nivel;
                    wod.tipoConteo = entity.tipoConteo;
                    entities.SaveChanges();
                }
            }
        }
    }
}
