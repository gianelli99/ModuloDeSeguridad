using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Logica.Interfaces
{
    interface ISesionPublisher
    {
        List<ISesionObserver> Observadores { get; set; }
        void Suscribir(ISesionObserver observer);
        void Desuscribir(ISesionObserver observer);
        void Notificar();
    }
}
