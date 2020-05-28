using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Datos
{
    interface IGrupoDAO
    {
        List<Modelo.Grupo> Listar();
        void Insertar(Modelo.Grupo grupo, List<Modelo.Permiso> permisos);
        Modelo.Grupo Consultar(int id);
        void Modificar(Modelo.Grupo grupo, List<Modelo.Permiso> permisos);
        void Eliminar(int id);
        List<Modelo.Accion> ListarAcciones();
        List<Modelo.Vista> ListarVistas();
        List<int[]> ListarIDPermisos();
        List<int[]> ListarIDPermisos(int id);
        int CantidadUsuarios(int id);
    }
}
