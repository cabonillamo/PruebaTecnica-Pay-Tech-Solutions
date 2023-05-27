using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryEstadoTarea
    {
        //Esta es un interface para traer todos los estados de las tareas 
        IEnumerable<Estado_Tarea> GetEstadoTareas();
    }
}
