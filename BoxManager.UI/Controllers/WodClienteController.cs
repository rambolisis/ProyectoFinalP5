using System;
using BoxManager.BS;
using BoxManager.BS.DTO;
using BoxManager.BS.Models;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class WodClienteController : Controller
    {
        public ActionResult Index()
        {
            var tenantId = Session["TenantId"] != null ? (int)Session["TenantId"] : -1;

            if (tenantId == -1)
            {
                return Redirect("/");
            }

            var wodClienteService = new WodClienteService();
            var wodClientes = wodClienteService.GetByTenantId(tenantId).Select(w => new WodClienteModel()
            {
                Id = w.Id,
                Descripcion = w.Descripcion,
                Fecha = w.Fecha,
                Cliente = w.Cliente,
                TipoConteo = w.TipoConteo
            }).ToList();

            return View("Index", wodClientes);
        }

        public ActionResult Modificar(int? id)
        {
            var wodClienteService = new WodClienteService();
            var tiposConteoService = new TipoConteoService();
            var clientesService = new ClienteService();
            var tenantId = Session["TenantId"] != null ? (int)Session["TenantId"] : -1;

            var model = new WodClienteModel();
            model.Fecha = DateTime.Now;

            if (id.HasValue)
            {
                var wodClienteDTO = wodClienteService.GetById(id.Value);
                if (wodClienteDTO != null)
                {
                    model.Id = wodClienteDTO.Id;
                    model.Descripcion = wodClienteDTO.Descripcion;
                    model.Fecha = wodClienteDTO.Fecha;
                    model.IdCliente = wodClienteDTO.IdCliente;
                    model.IdTipoConteo = wodClienteDTO.IdTipoConteo;
                    model.IdTenant = wodClienteDTO.IdTenant;
                }
            }

            model.Clientes = clientesService.GetByTenantId(tenantId);
            model.TiposConteo = tiposConteoService.GetByTenantId(tenantId);

            return View("Detalles", model);
        }

        public ActionResult Guardar(WodClienteModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect(model.ReturnUrl);
            }

            var tenantId = Session["TenantId"] != null ? (int)Session["TenantId"] : -1;
            model.IdTenant = tenantId;

            var wodClienteService = new WodClienteService();
            var wodClienteDto = new WodDTO()
            {
                Id = model.Id,
                Descripcion = model.Descripcion,
                Fecha = model.Fecha,
                IdCliente = model.IdCliente,
                IdTipoConteo = model.IdTipoConteo,
                IdTenant = tenantId
            };

            wodClienteService.Save(wodClienteDto);

            return Redirect(model.ReturnUrl);
        }

        public ActionResult Borrar(int id)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Wod");
            }

            var wodClienteService = new WodClienteService();
            wodClienteService.Delete(id);

            return Index();
        }
    }
}