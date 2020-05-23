using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Datos
{
    interface IUsuarioDAO : ICrud<Modelo.Usuario> 
    {
        List<Modelo.Vista> ListarVistasDisponibles(int id);

        List<Modelo.Accion> ListarAccionesDisponibles(int idUser, int idVista);
    }
}
