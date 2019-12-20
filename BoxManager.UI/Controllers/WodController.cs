using System;
using BoxManager.BS;
using BoxManager.BS.DTO;
using BoxManager.BS.Models;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class WodController : Controller
    {
        public ActionResult Index()
        {
            var tenantId = Session["TenantId"] != null ? (int)Session["TenantId"] : -1;

            if (tenantId == -1)
            {
                return Redirect("/");
            }

            var wodService = new WodService();
            var wods = wodService.GetByTenantId(tenantId).Select(w => new WodModel()
            {
                Id = w.Id,
                Descripcion = w.Descripcion,
                Fecha = w.Fecha,
                Nivel = w.Nivel,
                TipoConteo = w.TipoConteo
            }).ToList();

            return View("Index", wods);
        }

        public ActionResult Modificar(int? id)
        {
            var wodService = new WodService();
            var tiposConteoService = new TipoConteoService();
            var nivelesService = new NivelService();
            var tenantId = Session["TenantId"] != null ? (int)Session["TenantId"] : -1;

            var model = new WodModel();
            model.Fecha = DateTime.Now;

            if (id.HasValue)
            {
                var wodDTO = wodService.GetById(id.Value);
                if (wodDTO != null)
                {
                    model.Id = wodDTO.Id;
                    model.Descripcion = wodDTO.Descripcion;
                    model.Fecha = wodDTO.Fecha;
                    model.IdNivel = wodDTO.IdNivel;
                    model.IdTipoConteo = wodDTO.IdTipoConteo;
                    model.IdTenant = wodDTO.IdTenant;
                }
            }

            model.Niveles = nivelesService.GetByTenantId(tenantId);
            model.TiposConteo = tiposConteoService.GetByTenantId(tenantId);

            return View("Detalles", model);
        }

        public ActionResult Guardar(WodModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect(model.ReturnUrl);
            }

            var tenantId = Session["TenantId"] != null ? (int)Session["TenantId"] : -1;
            model.IdTenant = tenantId;

            var wodService = new WodService();
            var wodDto = new WodDTO()
            {
                Id = model.Id,
                Descripcion = model.Descripcion,
                Fecha = model.Fecha,
                IdNivel = model.IdNivel,
                IdTipoConteo = model.IdTipoConteo,
                IdTenant = tenantId
            };

            wodService.Save(wodDto);

            return Redirect(model.ReturnUrl);
        }

        public ActionResult Borrar(int id)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Wod");
            }

            var wodService = new WodService();
            wodService.Delete(id);

            return Index();
        }
    }
}