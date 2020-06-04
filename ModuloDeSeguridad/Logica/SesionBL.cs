using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModuloDeSeguridad.Logica.Interfaces;

namespace ModuloDeSeguridad.Logica
{
    public class SesionBL : Interfaces.ISesionPublisher
    {
        private Datos.Interfaces.ISesionDAO sesionDAO;
        private Datos.Interfaces.IUsuarioDAO usuarioDAO;        

        private List<Interfaces.ISesionObserver> observadores;

        private static SesionBL instancia;

        public static SesionBL ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new SesionBL();
            }
            return instancia;
        }
        private SesionBL()
        {
            sesionDAO = new Datos.DAO.SesionDAO_SqlServer();
            usuarioDAO = new Datos.DAO.UsuarioDAO_SqlServer();
            observadores = new List<ISesionObserver>();
        }
        public int ValidarUsuario(string username, string password)
        {
            try
            {
                return sesionDAO.ValidarUsuario(username, password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Modelo.Usuario ConsultarUsuario(int id)
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
        public List<Modelo.Vista> ListarVistasDisponibles(int userId)
        {
            try
            {
                return usuarioDAO.ListarVistasDisponibles(userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void IniciarSesion()
        {
            try
            {
                int id = sesionDAO.IniciarSesion(Modelo.Sesion.ObtenerInstancia());
                Modelo.Sesion.ObtenerInstancia().ID = id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Suscribir(ISesionObserver observer)
        {
            observadores.Add(observer);
        }
        public void Desuscribir(ISesionObserver observer)
        {
            observadores.Remove(observer);
        }
        public void FinalizarSesion()
        {
            this.Notificar();
            Modelo.Sesion.ObtenerInstancia().LogOut = DateTime.Now;
            try
            {
                sesionDAO.CerrarSesion(Modelo.Sesion.ObtenerInstancia()); 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Notificar()
        {
            for (int i = observadores.Count-1; i >= 0; i--)
            {
                observadores[i].Actualizar();
            }
        }
    }
}
