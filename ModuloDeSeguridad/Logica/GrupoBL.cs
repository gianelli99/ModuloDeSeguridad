using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Logica
{
    public class GrupoBL
    {
        private Datos.IGrupoDAO grupoDAO;
        private Datos.IUsuarioDAO usuarioDAO;
        public GrupoBL()
        {
            grupoDAO = new Datos.GrupoDAO_SqlServer();
            usuarioDAO = new Datos.UsuarioDAO_SqlServer();
        }

        public List<Modelo.Accion> ListarAccionesDisponibles(int userId,int vistaId)
        {
            return usuarioDAO.ListarAccionesDisponibles(userId, vistaId);
        }
        public void Insertar(Modelo.Grupo group, List<Modelo.Permiso> permisos)
        {
            try
            {
                if (DescripcionCodigoDisponible(group.Descripcion, group.Codigo))
                {
                    grupoDAO.Insertar(group, permisos);
                }
                else
                {
                    throw new Exception("La descripción no está disponible");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Modificar(Modelo.Grupo group, List<Modelo.Permiso> permisos)
        {
            try
            {
                if (DescripcionCodigoDisponible(group.Descripcion,group.Codigo,group.ID))
                {
                    grupoDAO.Modificar(group, permisos);
                }
                else
                {
                    throw new Exception("La descripción no está disponible");
                }
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
                int users = grupoDAO.CantidadUsuarios(id);
                if (users == 0)
                {
                    grupoDAO.Eliminar(id);
                }
                else
                {
                    throw new Exception("Este grupo posee " + users + " usuarios, no puede ser eliminado.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Modelo.Grupo Consultar(int id)
        {
            return grupoDAO.Consultar(id);
        }
        public List<Modelo.Grupo> Listar()
        {
            return grupoDAO.Listar();
        }
        public List<Modelo.Grupo> Listar(List<Modelo.Grupo> grupos, string filtro)
        {
            return grupos.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()));
        }
        public List<Modelo.Permiso> ListarPermisos()//este se usa en el alta
        {
            List<int[]> permisosID = grupoDAO.ListarIDPermisos();
            var vistas = grupoDAO.ListarVistas();
            var acciones = grupoDAO.ListarAcciones();
            if (permisosID.Count >0)
            {
                List<Modelo.Permiso> permisos = new List<Modelo.Permiso>();
                foreach (var permisoID in permisosID)
                {
                    var permiso = new Modelo.Permiso();
                    foreach (var accion in acciones)// revisar foreach y findT de la lista
                    {
                        if (accion.ID == permisoID[0])
                        {
                            permiso.Accion = accion;
                            break;
                        }
                    }
                    foreach (var vista in vistas)// revisar foreach y findT de la lista
                    {
                        if (vista.ID == permisoID[1])
                        {
                            permiso.Vista = vista;
                            break;
                        }
                    }
                    permiso.TienePermiso = false;
                    permisos.Add(permiso);
                }
                return permisos;
            }
            else
            {
                return null;// exception ha ocurido un error, contactese con un administrador para resolver el problema
            }


        }
        public List<Modelo.Permiso> ListarPermisos(int id)// se usa en mod y consulta
        {
            try
            {
                var grupo = grupoDAO.Consultar(id);
                var vistas = grupoDAO.ListarVistas();
                var acciones = grupoDAO.ListarAcciones();
                var permisosID = grupoDAO.ListarIDPermisos(id);
                var permisos = new List<Modelo.Permiso>();
                    foreach (var permisoID in permisosID)// validar que tenga datos
                    {
                        var permiso = new Modelo.Permiso();
                        permiso.ID = permisoID[0];
                        permiso.Grupo = grupo;
                        foreach (var vista in vistas)
                        {
                            if (vista.ID == permisoID[1])
                            {
                                permiso.Vista = vista;
                                break;
                            }
                        }
                        foreach (var accion in acciones)
                        {
                            if (accion.ID == permisoID[2])
                            {
                                permiso.Accion = accion;
                                break;
                            }
                        }
                        permiso.TienePermiso = permisoID[3] == 1 ? true : false;
                        permisos.Add(permiso);
                    }
                    return permisos;
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error, contacte a un administrador");
            }
        }
        private bool DescripcionCodigoDisponible(string descripción, string codigo)
        {
            try
            {
                var grupos = grupoDAO.Listar();
                foreach (var grupo in grupos)
                {
                    if (grupo.Codigo == codigo || grupo.Descripcion == descripción)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool DescripcionCodigoDisponible(string descripción,string codigo, int id)
        {
            try
            {
                var grupos = grupoDAO.Listar();
                foreach (var grupo in grupos)
                {
                    if ((grupo.Codigo == codigo || grupo.Descripcion == descripción) && grupo.ID != id)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
