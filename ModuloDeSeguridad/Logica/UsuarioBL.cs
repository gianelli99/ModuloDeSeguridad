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
        public Modelo.Usuario Consultar(string username, string email)
        {
            try
            {
                return usuarioDAO.Consultar(username,email);
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
        public void Eliminar(int id, int idEditor)
        {
            try
            {
                 usuarioDAO.Eliminar(id, idEditor);
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
        public void Insertar(Modelo.Usuario usuario, int idEditor)
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
                        usuario.Password = Hasheo.GetMd5Hash(usuario.Password);
                        usuarioDAO.Insertar(usuario, idEditor);
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
        public void Modificar(Modelo.Usuario usuario, int idEditor,bool modificaGrupo)
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
                        usuarioDAO.Modificar(usuario, idEditor, modificaGrupo);
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
        public bool ValidarContrasena(Modelo.Usuario usuario,string actual,string nueva)
        {
            if (Hasheo.VerifyMd5Hash(actual, usuario.Password))
            {
                if (actual!=nueva)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void CambiarContrasena(string pass, int userId, int editorId)
        {
            try
            {
                pass = Hasheo.GetMd5Hash(pass);
                usuarioDAO.CambiarContrasena(pass, userId, editorId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
