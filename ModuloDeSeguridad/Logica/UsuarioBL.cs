using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Logica
{
    public class UsuarioBL
    {
        private Datos.IUsuarioDAO usuarioDAO;
        private Datos.IGrupoDAO grupoDAO;

        public UsuarioBL()
        {
            usuarioDAO = new Datos.UsuarioDAO_SqlServer();
            grupoDAO = new Datos.GrupoDAO_SqlServer();
        }
        public Modelo.Usuario Consultar(int id)
        {
            return usuarioDAO.Consultar(id);
        }
        public List<Modelo.Accion> ListarAccionesDisponibles(int userId, int vistaId)
        {
            return usuarioDAO.ListarAccionesDisponibles(userId, vistaId);
        }
        public List<Modelo.Usuario> Listar()
        {
            return usuarioDAO.Listar();
        }
        public List<Modelo.Usuario> Listar(List<Modelo.Usuario> usuarios, string filtro)
        {
            return usuarios.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Apellido.ToUpper().Contains(filtro.ToUpper()) || x.Username.ToUpper().Contains(filtro.ToUpper()));
        }
        public void Eliminar(int id)
        {
            try
            {
                 usuarioDAO.Eliminar(id);
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido eliminar el usuario");
            }
        }
        public List<Modelo.Grupo> ListarGrupos()
        {
            return grupoDAO.Listar();
        }
        public List<Modelo.Grupo> ListarGrupos(int userId)
        {
            return usuarioDAO.ListarGrupos(userId);
        }
    }
}
