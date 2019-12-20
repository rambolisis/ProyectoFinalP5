using BoxManager.DAL;

namespace BoxManager.BS
{
    public class LoginService
    {
        public int Login(string usuario, string password) 
        {
            var tenantId = -1;

            var dbUsuario = new AdministradorDAL().GetAdministrador(usuario);
            if (dbUsuario != null && dbUsuario.contrasenia == password) 
            {
                tenantId = dbUsuario.idTenant;
            }

            return tenantId;
        }
    }
}
