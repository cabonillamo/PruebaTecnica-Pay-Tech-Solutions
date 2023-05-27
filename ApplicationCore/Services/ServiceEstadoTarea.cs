using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEstadoTarea : IServiceEstadoTarea
    {
        /*Este metodo se trae la interface de IServiceEstadoTarea
          y crea una conexión entre proyectos MVC para traer los datos
          de la base de datos que se extrageron en el proyecto de infraestructura
          folder Repository
        */
        public IEnumerable<Estado_Tarea> GetEstadoTareas()
        {
            IRepositoryEstadoTarea repositoryEstadoTarea = new RepositoryEstadoTarea();
            return repositoryEstadoTarea.GetEstadoTareas();
        }
    }
}
