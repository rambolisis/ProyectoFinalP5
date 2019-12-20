using BoxManager.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BoxManager.DAL
{
    public class WodClienteDAL : ICRUD<wodCliente>, IGetAll<wodCliente>
    {
        public void Delete(int wodClienteId)
        {
            using (var entities = new BoxManagerEntities())
            {
                var wodCliente = entities.wodClientes.FirstOrDefault(w => w.id == wodClienteId);
                if (wodCliente != null)
                {
                    entities.wodClientes.Remove(wodCliente);
                    entities.SaveChanges();
                }
            }
        }

        public wodCliente Get(int wodClienteId)
        {
            using (var entities = new BoxManagerEntities())
            {
                var wodCliente = entities.wodClientes.FirstOrDefault(w => w.id == wodClienteId);
                return wodCliente;
            }
        }

        public List<wodCliente> GetAll(int tenantId)
        {
            using (var entities = new BoxManagerEntities())
            {
                var wodClientes = entities.wodClientes.Where(w => w.idTenant == tenantId)
                    .Include("cliente1")
                    .Include("tipoConteo1")
                    .ToList();
                return wodClientes;
            }
        }

        public void Insert(wodCliente entity)
        {
            using (var entities = new BoxManagerEntities())
            {
                entities.wodClientes.Add(entity);
                entities.SaveChanges();
            }
        }

        public void Update(wodCliente entity)
        {
            using (var entities = new BoxManagerEntities())
            {
                var wodCliente = entities.wodClientes.FirstOrDefault(w => w.id == entity.id);
                if (wodCliente != null)
                {
                    wodCliente.descripcion = entity.descripcion;
                    wodCliente.fecha = entity.fecha;
                    wodCliente.cliente = entity.cliente;
                    wodCliente.tipoConteo = entity.tipoConteo;
                    entities.SaveChanges();
                }
            }
        }
    }
}
