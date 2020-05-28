using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloDeSeguridad.Modelo;
using System.Data.SqlClient;

namespace ModuloDeSeguridad.Datos
{
    public class GrupoDAO_SqlServer : ConexionDB, IGrupoDAO
    {
        public int CantidadUsuarios(int id)
        {
            SqlCommand query = new SqlCommand("SELECT COUNT(usuario_id) AS cantidad FROM usuarios_grupos WHERE grupo_id = "+ id, Conexion);
            Conexion.Open();
            SqlDataReader response = query.ExecuteReader();
            if (response.HasRows)
            {
                if (response.Read())
                {
                    int cant= response.GetInt32(0);
                    Conexion.Close();
                    return cant;
                }
                else
                {
                    Conexion.Close();
                    throw new Exception("Ha ocurrido un error, contacte al administrador para más información");
                }
            }
            else
            {
                Conexion.Close();
                throw new Exception("Ha ocurrido un error, contacte al administrador para más información");
            }
        }

        public Grupo Consultar(int id)
        {
            SqlCommand query = new SqlCommand("SELECT * FROM grupos WHERE id = "+id, Conexion);
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
            try
            {
                SqlCommand query = new SqlCommand("DELETE FROM permisos WHERE grupo_id = " + id, Conexion);//falta validaciones
                Conexion.Open();
                query.ExecuteNonQuery();
                Conexion.Close();
                Conexion.Open();
                query = new SqlCommand("DELETE FROM grupos WHERE id = " + id, Conexion);//falta validaciones
                query.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insertar(Grupo t, List<Modelo.Permiso> permisos)
        {
            try
            {
                int bitEstado = t.Estado ? 1 : 0;
                SqlCommand query = new SqlCommand("INSERT INTO grupos VALUES('" + t.Codigo + "','" + t.Descripcion + "'," + bitEstado.ToString() + ")", Conexion);
                Conexion.Open();
                query.ExecuteNonQuery();
                Conexion.Close();


                query = new SqlCommand($"SELECT TOP 1 id FROM grupos WHERE descripcion = '{t.Descripcion}'", Conexion);
                Conexion.Open();
                SqlDataReader response = query.ExecuteReader();
                if (response.HasRows)
                {
                    if (response.Read())
                    {
                        t.ID = response.GetInt32(0);
                    }
                }
                Conexion.Close();

                string querypermisos = "INSERT INTO permisos VALUES ";
                foreach (var permiso in permisos)
                {
                    int tienePermiso = permiso.TienePermiso ? 1 : 0;
                    querypermisos += $"('{t.ID.ToString()}','{permiso.Vista.ID.ToString()}','{permiso.Accion.ID.ToString()}','{tienePermiso.ToString()}'),";
                }
                string finalquery = querypermisos.TrimEnd(',');
                Conexion.Open();
                query = new SqlCommand(finalquery, Conexion);
                query.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Grupo> Listar()
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
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

        public List<int[]> ListarIDPermisos()// en alta
        {
            SqlCommand query = new SqlCommand("SELECT DISTINCT accion_id, vista_id FROM permisos", Conexion);
            Conexion.Open();
            SqlDataReader response = query.ExecuteReader();
            if (response.HasRows)
            {
                var permisos = new List<int[]>();
                while (response.Read())
                {
                    var permiso = new int[2];
                    permiso[0] = response.GetInt32(0);//accion id
                    permiso[1] = response.GetInt32(1);//vista id
                    permisos.Add(permiso);
                }
                Conexion.Close();
                return permisos;

            }
            Conexion.Close();
            return null;
        }

        public List<int[]> ListarIDPermisos(int id)// mod y consulta
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

        public void Modificar(Grupo t, List<Modelo.Permiso> permisos)
        {
            try
            {
                int bitEstado = t.Estado ? 1 : 0;
                SqlCommand query = new SqlCommand("UPDATE grupos SET codigo='" + t.Codigo + "', descripcion='" + t.Descripcion + "', estado=" + bitEstado.ToString() + " WHERE id = " + t.ID, Conexion);
                Conexion.Open();
                query.ExecuteNonQuery();
                Conexion.Close();

                string querypermisos = "";
                foreach (var permiso in permisos)
                {
                    int tienePermiso = permiso.TienePermiso ? 1 : 0;
                    querypermisos += $"UPDATE permisos SET tiene_permiso = '{tienePermiso.ToString()}' WHERE id = '{permiso.ID.ToString()}';";
                }
                Conexion.Open();
                query = new SqlCommand(querypermisos, Conexion);
                query.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
