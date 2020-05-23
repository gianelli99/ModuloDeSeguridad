using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Modelo
{
    public class Sesion
    {
        public int ID { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime LogIn { get; set; }
        public DateTime LogOut { get; set; }
        public TimeSpan MaxTime { get; set; }
        public TimeSpan CalcularTiempoSesion()
        {
            return LogOut - LogIn;
        }
    }
}
