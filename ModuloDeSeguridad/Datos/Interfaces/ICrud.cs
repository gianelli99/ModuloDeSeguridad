using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDeSeguridad.Datos
{
    interface ICrud<T>
    {
        List<T> Listar();
        void Insertar(T t);
        T Consultar(int id);
        void Modificar(T t);
        void Eliminar(int id);
    }
}
