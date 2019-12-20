using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxManager.DAL
{
    public class AdministradorDAL
    {
        public administrador GetAdministrador(string usuario) 
        {
            using (var entities = new BoxManagerEntities()) 
            {
                var admin = entities.administradors.Where(a => a.usuario == usuario).FirstOrDefault();
                return admin;
            }
        }
    }
}
