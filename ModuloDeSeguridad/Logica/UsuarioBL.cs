using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Logica
{
    public class UsuarioBL
    {
        private Datos.Interfaces.IUsuarioDAO usuarioDAO;
        private Datos.Interfaces.IGrupoDAO grupoDAO;

        public UsuarioBL()
        {
            usuarioDAO = new Datos.DAO.UsuarioDAO_SqlServer();
            grupoDAO = new Datos.DAO.GrupoDAO_SqlServer();
        }
        public Modelo.Usuario Consultar(int id)
        {
            try
            {
                return usuarioDAO.Consultar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Modelo.Accion> ListarAccionesDisponibles(int userId, int vistaId)
        {
            try
            {
                return usuarioDAO.ListarAccionesDisponibles(userId, vistaId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Modelo.Usuario> Listar()
        {
            try
            {
                return usuarioDAO.Listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Modelo.Usuario> Listar(List<Modelo.Usuario> usuarios, string filtro)
        {
            try
            {
                return usuarios.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Apellido.ToUpper().Contains(filtro.ToUpper()) || x.Username.ToUpper().Contains(filtro.ToUpper()));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Eliminar(int id)
        {
            try
            {
                 usuarioDAO.Eliminar(id);
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido eliminar el usuario");
            }
        }
        public List<Modelo.Grupo> ListarGrupos()
        {
            try
            {
                return grupoDAO.Listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Modelo.Grupo> ListarGrupos(int userId)
        {
            try
            {
                return usuarioDAO.ListarGrupos(userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Insertar(Modelo.Usuario usuario)
        {
            try
            {
                if (usuario.Grupos.Count == 0)
                {
                    throw new Exception("Debe asignar al menos un grupo al usuario");
                }
                else
                {
                    if (UsernameEmailDisponibles(usuario.Username,usuario.Email, null))
                    {
                        usuarioDAO.Insertar(usuario);
                    }
                    else
                    {
                        throw new Exception("Username o email no estan disponibles");
                    } 
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private bool UsernameEmailDisponibles(string username, string email, string id)
        {
            try
            {
                return usuarioDAO.UsernameEmailDisponibles(username, email, id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Modificar(Modelo.Usuario usuario)
        {
            try
            {
                if (usuario.Grupos.Count == 0)
                {
                    throw new Exception("Debe asignar al menos un grupo al usuario");
                }
                else
                {
                    if (UsernameEmailDisponibles(usuario.Username, usuario.Email, usuario.ID.ToString()))
                    {
                        usuarioDAO.Modificar(usuario);
                    }
                    else
                    {
                        throw new Exception("Username o email no estan disponibles");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
