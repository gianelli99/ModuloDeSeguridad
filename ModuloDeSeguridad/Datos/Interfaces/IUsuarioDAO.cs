using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Datos.Interfaces
{
    interface IUsuarioDAO
    {
        List<Modelo.Usuario> Listar();
        List<Modelo.Grupo> ListarGrupos(int id);
        void Insertar(Modelo.Usuario t, int idEditor);
        Modelo.Usuario Consultar(int id);
        void Modificar(Modelo.Usuario t, int idEditor);
        void Eliminar(int id, int idEditor);
        List<Modelo.Vista> ListarVistasDisponibles(int id);
        List<Modelo.Accion> ListarAccionesDisponibles(int idUser, int idVista);
        bool UsernameEmailDisponibles(string username, string email, string id);
    }
}
