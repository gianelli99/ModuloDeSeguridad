using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Logica
{
    public class GrupoBL
    {
        private Datos.GrupoDAO grupoDAO = new Datos.GrupoDAO();
        private Datos.UsuarioDAO usuarioDAO = new Datos.UsuarioDAO();

        public List<Modelo.Accion> ListarAccionesDisponibles(int userId,int vistaId)
        {
            return usuarioDAO.ListarAccionesDisponibles(userId, vistaId);
        }
        public void Insertar(Modelo.Grupo group)
        {
            //validaciones
            grupoDAO.Insertar(group);
        }
        public void Modificar(Modelo.Grupo group)
        {
            grupoDAO.Modificar(group);
        }
        public void Eliminar(int id)
        {
            grupoDAO.Eliminar(id);
        }
        public Modelo.Grupo Consultar(int id)
        {
            return grupoDAO.Consultar(id);
        }
        public List<Modelo.Grupo> Listar()
        {
            return grupoDAO.Listar();
        }
        public List<Modelo.Grupo> Listar(List<Modelo.Grupo> grupos, string filtro)
        {
            return grupos.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()));
        }
        public List<Modelo.Permiso> ListarPermisos(int id)
        {
            return grupoDAO.ListarPermisos(id);
        }

    }
}
