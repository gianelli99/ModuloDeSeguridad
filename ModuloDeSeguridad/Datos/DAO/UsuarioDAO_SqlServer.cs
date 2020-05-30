using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloDeSeguridad.Modelo;
using System.Data.SqlClient;

namespace ModuloDeSeguridad.Datos
{
    public class UsuarioDAO_SqlServer : ConexionDB,IUsuarioDAO
    {

        public Usuario Consultar(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Consulta Usuario");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = $"SELECT TOP 1 * from usuarios WHERE id = {id};SELECT grupos.id, grupos.codigo, grupos.descripcion,grupos.estado FROM grupos INNER JOIN usuarios_grupos ON grupos.id = usuarios_grupos.grupo_id WHERE usuarios_grupos.usuario_id = {id}";
                    transaction.Commit();
                    using (SqlDataReader response = command.ExecuteReader())
                    {
                        var usuario = new Usuario();
                        if (response.Read())
                        {
                            usuario.ID = response.GetInt32(0);
                            usuario.Username = response.GetString(1);
                            usuario.Password = response.GetString(2);
                            usuario.Email = response.GetString(3);
                            usuario.Nombre = response.GetString(4);
                            usuario.Apellido = response.GetString(5);
                            usuario.Estado = response.GetBoolean(6);
                        }
                        response.NextResult();
                        while (response.Read())
                        {
                            var grupo = new Grupo();
                            grupo.ID = response.GetInt32(0);
                            grupo.Codigo = response.GetString(1);
                            grupo.Descripcion = response.GetString(2);
                            grupo.Estado = response.GetBoolean(3);
                            usuario.Grupos.Add(grupo);
                        }
                        return usuario;
                    }
                    throw new Exception("No se ha podido encontrar el grupo");
                }
                catch (Exception ex)
                {
                        throw ex;
                }
            }
            throw new Exception("Ha ocurrido un error");
        }

        public void Eliminar(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Eliminar usuario");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = $"DELETE FROM usuarios_grupos WHERE usuario_id = {id}; DELETE FROM usuarios WHERE id = {id}";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return;
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {

                        throw ex2;
                    }
                }
            }
            throw new Exception("Ha ocurrido un error");
        }

        public void Insertar(Usuario t)
        {
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Insertar usuario");

                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    int bitEstado = t.Estado ? 1 : 0;

                    command.CommandText = $"INSERT INTO usuarios VALUES(@username,@contrasena,@email,@nombre,@apelido,{bitEstado.ToString()});SELECT CAST(scope_identity() AS int)";
                    command.Parameters.AddWithValue("@username", t.Username);
                    command.Parameters.AddWithValue("@contrasena", t.Password);
                    command.Parameters.AddWithValue("@email", t.Email);
                    command.Parameters.AddWithValue("@nombre", t.Nombre);
                    command.Parameters.AddWithValue("@apelido", t.Apellido);
                    using (SqlDataReader response = command.ExecuteReader())
                    {
                        if (response.Read())
                        {
                            t.ID = response.GetInt32(0);
                        }
                    }
                    string querygrupos = $"INSERT INTO usuarios_grupos VALUES ";
                    foreach (var grupo in t.Grupos)
                    {
                        querygrupos += $"('{t.ID.ToString()}','{grupo.ID.ToString()}'),";
                    }
                    querygrupos = querygrupos.TrimEnd(',');
                    command.CommandText = querygrupos;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return;
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {

                        throw ex2;
                    }
                }
            }
            throw new Exception("Ha ocurrido un error");
        }

        public List<Usuario> Listar()
        {
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Listar usuarios");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = $"SELECT id,username,email,nombre,apellido,estado FROM usuarios";
                    transaction.Commit();
                    using (SqlDataReader response = command.ExecuteReader())
                    {
                        if (response.HasRows)
                        {
                            var usuarios = new List<Modelo.Usuario>();
                            while (response.Read())
                            {
                                var usuario = new Modelo.Usuario();

                                usuario.ID = response.GetInt32(0);
                                usuario.Username = response.GetString(1);
                                usuario.Email = response.GetString(2);
                                usuario.Nombre = response.GetString(3);
                                usuario.Apellido = response.GetString(4);
                                usuario.Estado = response.GetBoolean(5);
                                usuarios.Add(usuario);
                            }
                            return usuarios;
                        }
                    }
                }
                catch (Exception ex2)
                {
                        throw ex2;
                }
            }
            throw new Exception("Ha ocurrido un error");
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

        public List<Grupo> ListarGrupos(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Listar grupos del usuario");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = $"SELECT grupos.id, grupos.codigo, grupos.descripcion,grupos.estado FROM grupos INNER JOIN usuarios_grupos ON grupos.id = usuarios_grupos.grupo_id WHERE usuarios_grupos.usuario_id = {id}";
                    transaction.Commit();
                    using (SqlDataReader response = command.ExecuteReader())
                    {
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
                            return grupos;
                        }
                    }
                }
                catch (Exception ex2)
                {
                    throw ex2;
                }
            }
            throw new Exception("Ha ocurrido un error");
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
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Modificar usuario");

                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    int bitEstado = t.Estado ? 1 : 0;

                    command.CommandText = $"UPDATE usuarios SET username=@username, contrasena=@contrasena, email=@email, nombre=@nombre, apellido=@apelido, estado={bitEstado.ToString()} WHERE id = {t.ID.ToString()}";
                    command.Parameters.AddWithValue("@username", t.Username);
                    command.Parameters.AddWithValue("@contrasena", t.Password);
                    command.Parameters.AddWithValue("@email", t.Email);
                    command.Parameters.AddWithValue("@nombre", t.Nombre);
                    command.Parameters.AddWithValue("@apelido", t.Apellido);
                    command.ExecuteNonQuery();


                    string querygrupos = $"DELETE FROM usuarios_grupos WHERE usuario_id = {t.ID};";


                    querygrupos += $"INSERT INTO usuarios_grupos VALUES ";
                    foreach (var grupo in t.Grupos)
                    {
                        querygrupos += $"('{t.ID.ToString()}','{grupo.ID.ToString()}'),";
                    }
                    querygrupos = querygrupos.TrimEnd(',');
                    command.CommandText = querygrupos;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    return;
                }
                catch (Exception)
                {
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {

                        throw ex2;
                    }
                }
            }
            throw new Exception("Ha ocurrido un error");
        }

        public bool UsernameEmailDisponibles(string username, string email, string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Validacion username y correo");

                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    string optionalQuery = id != null ? $" AND id <> {id}" : "";
                    command.CommandText = $"SELECT count(id) AS cantidad FROM usuarios WHERE (username = @username OR email = @email)" + optionalQuery;
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@email", email);
                    transaction.Commit();
                    using (SqlDataReader response = command.ExecuteReader())
                    {
                        if (response.Read())
                        {
                            return response.GetInt32(0) > 0 ? false : true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            throw new Exception("Ha ocurrido un error");
        }
    }
}
