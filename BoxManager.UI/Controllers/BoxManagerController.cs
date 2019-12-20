using System.Linq;
using BoxManager.BS;
using BoxManager.BS.Models;
using System.Web.Mvc;
using BoxManager.BS.DTO;

namespace WebApplication1.Controllers
{
    public class BoxManagerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Index");
            }

            var loginService = new LoginService();
            var tenantId = loginService.Login(model.Usuario, model.Password);

            Session["TenantId"] = tenantId;

            if (tenantId != -1) 
            {                
                return Redirect(model.ReturnUrl);
            }

            return Redirect("Index");
        }

        public ActionResult Logout()
        {
            Session.Remove("TenantId");
            return Redirect("Index");
        }
    }
}