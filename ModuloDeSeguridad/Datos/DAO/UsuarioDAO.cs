using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloDeSeguridad.Modelo;
using System.Data.SqlClient;

namespace ModuloDeSeguridad.Datos
{
    public class UsuarioDAO : ConexionDB,IUsuarioDAO
    {

        public Usuario Consultar(int id)
        {
            SqlCommand query = new SqlCommand("SELECT COUNT(tiene_permiso) as cantidad_permisos,vista_id,vistas.nombre from permisos inner join vistas on permisos.vista_id = vistas.id where grupo_id IN (SELECT grupo_id FROM usuarios_grupos WHERE usuario_id = "+id+") group by vista_id, nombre", Conexion);
            Conexion.Open();
            SqlDataReader response = query.ExecuteReader();
            if (response.HasRows)
            {
                Usuario user = new Usuario();
                user.ID = 1;
                user.Nombre = "gian";
                user.Grupos = new List<Grupo>();
                while (response.Read())
                {
                    return null;
                }
            }
            return null;

        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Usuario t)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar(string filtro)
        {
            throw new NotImplementedException();
        }

        public List<Accion> ListarAccionesDisponibles(int idUser, int idVista)
        {
            SqlCommand query = new SqlCommand("SELECT distinct acciones.id, acciones.tipo from permisos inner join acciones on permisos.accion_id = acciones.id where permisos.grupo_id in (SELECT grupo_id FROM usuarios_grupos WHERE usuario_id = "+idUser+") and vista_id = "+idVista+" and tiene_permiso = 1", Conexion);
            Conexion.Open();
            SqlDataReader response = query.ExecuteReader();
            if (response.HasRows)
            {
                var acciones = new List<Modelo.Accion>();
                while (response.Read())
                {
                    var accion = new Modelo.Accion();
                    accion.ID = response.GetInt32(0);
                    accion.Descripcion = response.GetString(1);
                    acciones.Add(accion);
                }
                return acciones;
            }
            return null;
        }

        public List<Modelo.Vista> ListarVistasDisponibles(int id)
        {
            SqlCommand query = new SqlCommand("SELECT vista_id, vistas.nombre from permisos inner join vistas on permisos.vista_id = vistas.id where grupo_id IN(SELECT grupo_id FROM usuarios_grupos WHERE usuario_id = "+id+") group by vista_id, nombre having SUM(CAST(tiene_permiso as INT)) > 0", Conexion);
            Conexion.Open();
            SqlDataReader response = query.ExecuteReader();
            if (response.HasRows)
            {
                var vistas = new List<Modelo.Vista>();
                while (response.Read())
                {
                    var vista = new Modelo.Vista();
                    vista.ID = response.GetInt32(0);
                    vista.Descripcion = response.GetString(1);
                    vistas.Add(vista);
                }
                return vistas;
            }
            return null;
        }

        public void Modificar(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}
