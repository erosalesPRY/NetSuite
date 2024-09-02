using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos.NoTransaccional.Seguridad;
using EntidadNegocio.Seguridad;

namespace Controladora.Seguridad
{
    public class CUsuario
    {
        public DataTable GetPerfiles(int IdUser, string UserName)
        {
            return (new UsuarioNTAD()).GetUserInfo(IdUser, UserName);
        }
        public int ValidateUser(string login, string password)
        {
            return (new UsuarioNTAD()).ValidateUser(login, password);
        }

        public int ValidateUser(string login, string password,string LADP)
        {
            return (new UsuarioNTAD()).ValidateUserAD(login, password,LADP);
        }

        public bool VerificaCaducidadUser(int IdUsuario)
        {
            return (new UsuarioNTAD()).VerificaCaducidadUser(IdUsuario);
        }
        public DataTable GetOptionsByProfile(int idSystem, int idProfile, string pagina)
        {
            return (new UsuarioNTAD()).GetOptionsByProfile(idSystem, idProfile, pagina);
        }

        public DataTable GetPerfilAccesoDirecto(int idSystem, int idUsuario)
        {
            return (new UsuarioNTAD()).GetPerfilAccesoDirecto(idSystem, idUsuario);
        }
        public UsuarioBE GetDatosUsuario(int idUsuario)
        {
            return (new UsuarioNTAD()).GetDatosUsuario(idUsuario);
        }
    }
}
