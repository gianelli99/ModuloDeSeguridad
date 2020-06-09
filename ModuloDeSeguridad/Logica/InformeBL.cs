using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ModuloDeSeguridad.Logica
{
    public class InformeBL
    {
        private Datos.Interfaces.ISesionDAO sesionDAO;
        public InformeBL()
        {
            sesionDAO = new Datos.DAO.SesionDAO_SqlServer();
        }
        public void GenerarInforme(DateTime fechaDesde, DateTime fechaHasta)//todos
        {
            try
            {
                List<Modelo.Sesion> sesiones = new List<Modelo.Sesion>();
                sesiones = sesionDAO.Listar(fechaDesde, fechaHasta);
                if (sesiones!= null)
                {
                    GenerarExcel(TipoInforme.Todos, sesiones, fechaDesde, fechaHasta);
                }
                else
                {
                    throw new Exception("No se han encontrado sesiones.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void GenerarInforme(TipoInforme tipoInforme, int id, DateTime fechaDesde, DateTime fechaHasta)// usuario y grupo
        {
            try
            {
                List<Modelo.Sesion> sesiones = new List<Modelo.Sesion>();
                if (tipoInforme == TipoInforme.Grupo)
                {
                    sesiones = sesionDAO.ListarPorGrupo(id, fechaDesde, fechaHasta);
                }
                else
                {
                    sesiones = sesionDAO.ListarPorUsuario(id, fechaDesde, fechaHasta);
                }
                GenerarExcel(tipoInforme,sesiones, fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void GenerarExcel(TipoInforme tipoInforme, List<Modelo.Sesion> sesiones, DateTime fechaDesde, DateTime fechaHasta)
        {
            Excel.Application oXL;
            Excel._Workbook oWB;
            Excel._Worksheet oSheet;
            Excel.Range oRng;
            try
            {
                oXL = new Excel.Application();
                oXL.Visible = true;

                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                string titulo = "";
                switch (tipoInforme)
                {
                    case TipoInforme.Todos:
                        titulo = $"Informe de Todas las sesiones desde {fechaDesde} hasta {fechaHasta}";
                        break;
                    case TipoInforme.Usuario:
                        titulo = $"Informe de Todas las sesiones del Usuario {sesiones[0].Usuario.Username} desde {fechaDesde} hasta {fechaHasta}";
                        break;
                    case TipoInforme.Grupo:
                        titulo = $"Informe de Todas las sesiones del Grupo {sesiones[0].Usuario.Grupos[0].Descripcion} desde {fechaDesde} hasta {fechaHasta}";
                        break;
                    default:
                        break;
                }
                oSheet.Cells[1, 1] = titulo;

                oSheet.Cells[2, 1] = "ID Sesión";
                oSheet.Cells[2, 2] = "Username";
                oSheet.Cells[2, 3] = "Fecha LogIn";
                oSheet.Cells[2, 4] = "Fecha LogOut";
                oSheet.Cells[2, 5] = "Tiempo de Sesión";


                string[,] ids = new string[sesiones.Count,5];
                for (int i = 0; i < sesiones.Count; i++)
                {
                    ids[i, 0] = sesiones[i].ID.ToString();
                    ids[i, 1] = sesiones[i].Usuario.Username;
                    ids[i, 2] = sesiones[i].LogIn.ToString();
                    ids[i, 3] = sesiones[i].LogOut.ToString();
                    ids[i, 4] = sesiones[i].CalcularTiempoSesion().ToString(@"hh\:mm\:ss");
                }
                oSheet.get_Range("A3", "E" + (sesiones.Count+2).ToString()).Value2 = ids;
                oRng = oSheet.get_Range("B1", "E1");
                oRng.EntireColumn.AutoFit();

                if (tipoInforme == TipoInforme.Usuario)
                {
                    oSheet.get_Range("B1").EntireColumn.Delete();
                }
                oXL.Visible = true;
                oXL.UserControl = true;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
