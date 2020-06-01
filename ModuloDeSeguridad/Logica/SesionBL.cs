using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Logica
{
    public class SesionBL
    {
        private Datos.Interfaces.ISesionDAO sesionDAO;
        private Datos.Interfaces.IUsuarioDAO usuarioDAO;
        public SesionBL()
        {
            sesionDAO = new Datos.DAO.SesionDAO_SqlServer();
            usuarioDAO = new Datos.DAO.UsuarioDAO_SqlServer();
        }
        public int ValidarUsuario(string username, string password)
        {
            try
            {
                return sesionDAO.ValidarUsuario(username, password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Modelo.Usuario ConsultarUsuario(int id)
        {
            try
            {
                return usuarioDAO.Consultar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Modelo.Vista> ListarVistasDisponibles(int userId)
        {
            try
            {
                return usuarioDAO.ListarVistasDisponibles(userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
