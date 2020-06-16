using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ModuloDeSeguridad.Logica.Interfaces;
using System.Timers;

namespace ModuloDeSeguridad.Logica
{
    public class SesionBL : Interfaces.ISesionPublisher
    {
        private Datos.Interfaces.ISesionDAO sesionDAO;
        private Datos.Interfaces.IUsuarioDAO usuarioDAO;        

        private List<Interfaces.ISesionObserver> observadores;

        private static SesionBL instancia;

        private static Timer sesionTime;

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
                password = Hasheo.GetMd5Hash(password);
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
                sesionTime = new Timer(7200000);
                sesionTime.Elapsed += SesionTime_Elapsed;
                sesionTime.AutoReset = true;
                sesionTime.Enabled = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void SesionTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            FinalizarSesion();
        }
        public void Suscribir(ISesionObserver observer)
        {
            observadores.Add(observer);
        }
        public bool FirstLogIn(int userId)
        {
            try
            {
                if (sesionDAO.LogInsCount(userId) == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Desuscribir(ISesionObserver observer)
        {
            observadores.Remove(observer);
        }
        public void FinalizarSesion()
        {
            if (sesionTime != null)
            {
                sesionTime.Dispose();
            }
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
            if (observadores.Count - 1>=0)
            {
                observadores[observadores.Count - 1].Actualizar(true);
            }
            for (int i = observadores.Count-1; i >= 0; i--)
            {
                observadores[i].Actualizar(false);
            }
        }
    }
}
