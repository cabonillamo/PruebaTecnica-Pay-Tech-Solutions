using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceEstadoTarea
    {
        //Esta es un interface para traer todos los estados de las tareas
        IEnumerable<Estado_Tarea> GetEstadoTareas();
    }
}
