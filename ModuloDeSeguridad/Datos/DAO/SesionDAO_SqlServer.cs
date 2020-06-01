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
        public void Insertar(Sesion sesion)
        {
            throw new NotImplementedException();
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

        public void Modificar(Sesion sesion)
        {
            throw new NotImplementedException();
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
