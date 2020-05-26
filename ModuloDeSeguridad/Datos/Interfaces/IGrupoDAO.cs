using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Datos
{
    interface IGrupoDAO : ICrud<Modelo.Grupo>
    {
        List<Modelo.Accion> ListarAcciones();
        List<Modelo.Vista> ListarVistas();
        List<Modelo.Permiso> ListarPermisos(int id);
    }
}
