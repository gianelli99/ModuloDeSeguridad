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
        public void Insertar(Modelo.Grupo group)
        {

        }
        public void Modificar(Modelo.Grupo group)
        {
        }
        public void Eliminar(int id)
        {
        }
        public Modelo.Grupo Consultar(int id)
        {
            return null;
        }
        public List<Modelo.Grupo> Listar()
        {
            return null;
        }
        public List<Modelo.Grupo> Listar(string filtro)
        {
            return null;
        }
        static public List<Modelo.Vista> ListarVistas()
        {
            return null;
        }
        static public List<Modelo.Accion> ListarAcciones()
        {
            return null;
        }
        public List<Modelo.Permiso> ListarPermisos(int id)
        {
            return grupoDAO.ListarPermisos(id);
        }

    }
}
