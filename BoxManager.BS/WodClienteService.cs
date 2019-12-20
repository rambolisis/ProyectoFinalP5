using BoxManager.BS.DTO;
using BoxManager.DAL;
using System.Collections.Generic;
using System.Linq;

namespace BoxManager.BS
{
    public class WodClienteService
    {
        public void Save(WodDTO wodDto)
        {
            var wodClienteDAL = new WodClienteDAL();

            var wodCliente = new wodCliente()
            {
                id = wodDto.Id,
                fecha = wodDto.Fecha,
                cliente = wodDto.IdCliente,
                descripcion = wodDto.Descripcion,
                tipoConteo = wodDto.IdTipoConteo,
                idTenant = wodDto.IdTenant
            };

            if (wodCliente.id == 0)
            {
                wodClienteDAL.Insert(wodCliente);
            }
            else
            {
                wodClienteDAL.Update(wodCliente);
            }
        }

        public WodDTO GetById(int wodClienteId)
        {
            var wodClienteDAL = new WodClienteDAL();
            var dbWodCliente = wodClienteDAL.Get(wodClienteId);
            var wodClienteDto = new WodDTO()
            {
                Id = dbWodCliente.id,
                Descripcion = dbWodCliente.descripcion,
                Fecha = dbWodCliente.fecha.Value,
                IdCliente = dbWodCliente.cliente.Value,
                IdTipoConteo = dbWodCliente.tipoConteo.Value,
                IdTenant = dbWodCliente.idTenant
            };

            return wodClienteDto;
        }

        public List<WodDTO> GetByTenantId(int tenantId)
        {
            var wodClienteDAL = new WodClienteDAL();
            var dbWodClientes = wodClienteDAL.GetAll(tenantId);

            var wodClientes = dbWodClientes.Select(w => new WodDTO
            {
                Id = w.id,
                Descripcion = w.descripcion,
                Fecha = w.fecha.Value,
                Cliente = w.cliente1.nombre,
                TipoConteo = w.tipoConteo1.nombre
            }).ToList();

            return wodClientes;
        }

        public void Delete(int wodClienteId)
        {
            var wodClienteDAL = new WodClienteDAL();
            wodClienteDAL.Delete(wodClienteId);
        }
    }
}
