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
            if (response.HasRows)
            {
                return new Grupo() { ID = 445};
            }
            return new Grupo() { ID = 000 };
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Grupo t)
        {
            throw new NotImplementedException();
        }

        public List<Grupo> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Grupo> Listar(string filtro)
        {
            throw new NotImplementedException();
        }

        public void Modificar(Grupo t)
        {
            throw new NotImplementedException();
        }
    }
}
