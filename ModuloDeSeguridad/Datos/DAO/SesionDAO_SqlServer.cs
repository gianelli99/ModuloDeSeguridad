using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloDeSeguridad.Modelo;
using System.Data.SqlClient;

namespace ModuloDeSeguridad.Datos.DAO
{
    public class SesionDAO_SqlServer : ConexionDB, Interfaces.ISesionDAO
    {
        public int IniciarSesion(Sesion sesion)
        {
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Iniciar sesión");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = $"INSERT INTO sesiones (usuario_id,inicio) VALUES({sesion.Usuario.ID},@inicio);SELECT CAST(scope_identity() AS int)";
                    command.Parameters.AddWithValue("@inicio", sesion.LogIn);
                    transaction.Commit();
                    using (SqlDataReader response = command.ExecuteReader())
                    {
                        if (response.Read())
                        {
                            return response.GetInt32(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                throw new Exception("Ha ocurrido un error");
            }
        }

        public List<Sesion> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Sesion> ListarPorGrupo(int idGrupo)
        {
            throw new NotImplementedException();
        }

        public List<Sesion> ListarPorUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void CerrarSesion(Sesion sesion)
        {
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Cerrar sesión");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = $"UPDATE sesiones SET cierre=@cierre WHERE id = {sesion.ID}";
                    command.Parameters.AddWithValue("@cierre", sesion.LogOut);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int ValidarUsuario(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionSQL))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("Validar Usuario");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = $"SELECT id FROM usuarios WHERE username = @username AND contrasena = @password AND estado = 1";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    transaction.Commit();
                    using (SqlDataReader response = command.ExecuteReader())
                    {
                        int usuarioId = -1;
                        if (response.Read())
                        {
                            usuarioId = response.GetInt32(0);
                        }
                        return usuarioId;
                    }
                    throw new Exception("No se ha podido encontrar el usuario");
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
