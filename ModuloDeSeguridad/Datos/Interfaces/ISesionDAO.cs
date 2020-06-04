using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Datos.Interfaces
{
    interface ISesionDAO
    {
        int ValidarUsuario(string username, string password);
        int IniciarSesion(Modelo.Sesion sesion);
        void CerrarSesion(Modelo.Sesion sesion);
        List<Modelo.Sesion> Listar();
        List<Modelo.Sesion> ListarPorGrupo(int idGrupo);
        List<Modelo.Sesion> ListarPorUsuario(int idUsuario);
    }
}
