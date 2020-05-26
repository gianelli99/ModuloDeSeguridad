using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloDeSeguridad.Modelo;
using System.Data.SqlClient;

namespace ModuloDeSeguridad.Datos
{
    public class GrupoDAO : ConexionDB, IGrupoDAO
    {
        public Grupo Consultar(int id)
        {
            SqlCommand query = new SqlCommand("SELECT * FROM grupos WHERE id = 1", Conexion);
            Conexion.Open();
            SqlDataReader response = query.ExecuteReader();
            
            if (response.Read())
            {
                var grupo = new Modelo.Grupo();

                grupo.ID = response.GetInt32(0);
                grupo.Codigo = response.GetString(1);
                grupo.Descripcion = response.GetString(2);
                grupo.Estado = response.GetBoolean(3);       
                Conexion.Close();
                return grupo;
            }
            Conexion.Close();
            return null;
        }

        public void Eliminar(int id)
        {
            SqlCommand query = new SqlCommand("DELETE FROM grupos WHERE id = "+ id, Conexion);//falta validaciones
            Conexion.Open();
            query.ExecuteNonQuery();
            Conexion.Close();
        }

        public void Insertar(Grupo t)
        {
            int bitEstado = t.Estado ? 1 : 0 ;
            SqlCommand query = new SqlCommand("INSERT INTO grupos VALUES('"+t.Codigo+"','"+t.Descripcion+"',"+bitEstado.ToString()+")", Conexion);
            Conexion.Open();
            query.ExecuteNonQuery();
            Conexion.Close();
        }

        public List<Grupo> Listar()
        {
            SqlCommand query = new SqlCommand("SELECT * FROM grupos", Conexion);
            Conexion.Open();
            SqlDataReader response = query.ExecuteReader();
            if (response.HasRows)
            {
                var grupos = new List<Modelo.Grupo>();
                while (response.Read())
                {
                    var grupo = new Modelo.Grupo();

                    grupo.ID = response.GetInt32(0);
                    grupo.Codigo = response.GetString(1);
                    grupo.Descripcion = response.GetString(2);
                    grupo.Estado = response.GetBoolean(3);
                    grupos.Add(grupo);
                }
                Conexion.Close();
                return grupos;
            }
            Conexion.Close();
            return null;
        }  

        public List<Accion> ListarAcciones()
        {
            SqlCommand query = new SqlCommand("SELECT * FROM acciones", Conexion);
            Conexion.Open();
            SqlDataReader response = query.ExecuteReader();
            
            if (response.HasRows)
            {
                var acciones = new List<Modelo.Accion>();
                while (response.Read())
                {
                    var accion = new Modelo.Accion()
                    {
                        ID = response.GetInt32(0),
                        Descripcion = response.GetString(1)
                    };
                    acciones.Add(accion);
                }
                Conexion.Close();
                return acciones;
            }
            Conexion.Close();
            return null;
        }

        private List<int[]> ListarIDPermisos(int id)
        {
            SqlCommand query = new SqlCommand("SELECT id, vista_id,accion_id,tiene_permiso FROM permisos WHERE grupo_id = "+ id, Conexion);
            Conexion.Open();
            SqlDataReader response = query.ExecuteReader();
            
            if (response.HasRows)
            {
                var permisos = new List<int[]>();
                while (response.Read())
                {
                    var permiso = new int[4];
                    permiso[0] = response.GetInt32(0);//id
                    permiso[1] = response.GetInt32(1);//vista
                    permiso[2] = response.GetInt32(2);//accion
                    permiso[3] = Convert.ToInt32(response.GetBoolean(3));//permiso
                    permisos.Add(permiso);
                }
                Conexion.Close();
                return permisos;

            }
            Conexion.Close();
            return null;
        }
        public List<Modelo.Permiso> ListarPermisos(int id)
        {
            var dao = new GrupoDAO();
            var grupo = dao.Consultar(id);
            var vistas = dao.ListarVistas();
            var acciones = dao.ListarAcciones();
            var permisosID = dao.ListarIDPermisos(id);
            var permisos = new List<Modelo.Permiso>(); 
            foreach (var arrPermiso in permisosID)// validar que tenga datos
            {
                var permiso = new Modelo.Permiso();
                permiso.ID = arrPermiso[0];
                permiso.Grupo = grupo;
                foreach (var vista in vistas)
                {
                    if (vista.ID == arrPermiso[1])
                    {
                        permiso.Vista = vista;
                        break;
                    }
                }
                foreach (var accion in acciones)
                {
                    if (accion.ID == arrPermiso[2])
                    {
                        permiso.Accion = accion;
                        break;
                    }
                }
                permiso.TienePermiso = arrPermiso[3] == 1 ? true : false ;
                permisos.Add(permiso);
            }
            return permisos;
        }

        public List<Modelo.Vista> ListarVistas()
        {
            SqlCommand query = new SqlCommand("SELECT * FROM vistas", Conexion);
            Conexion.Open();
            SqlDataReader response = query.ExecuteReader();
            
            if (response.HasRows)
            {
                var vistas = new List<Modelo.Vista>();
                while (response.Read())
                {
                    var vista = new Modelo.Vista()
                    {
                        ID = response.GetInt32(0),
                        Descripcion = response.GetString(1)
                    };
                    vistas.Add(vista);
                }
                Conexion.Close();
                return vistas;
            }
            Conexion.Close();
            return null;
        }

        public void Modificar(Grupo t)
        {
            int bitEstado = t.Estado ? 1 : 0;
            SqlCommand query = new SqlCommand("UPDATE grupos SET codigo='"+t.Codigo+"', descripcion='"+t.Descripcion+"', estado="+bitEstado.ToString()+" WHERE id = "+ t.ID, Conexion);
            Conexion.Open();
            query.ExecuteNonQuery();
            Conexion.Close();
        }
    }
}
