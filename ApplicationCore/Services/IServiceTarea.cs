using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceTarea
    {
        //Esta es una interface para traer todas la tareas
        IEnumerable<Trabajo> GetAll();
        //Esta es una interface para traer todas la tareas Pendientes
        IEnumerable<Trabajo> GetAllPendientes();
        //Esta es una interface para traer todas la tareas Completadas
        IEnumerable<Trabajo> GetAlCompletadasl();
        //Esta es una interface para traer ciertas tarea con su identificador
        Trabajo GetById(int id);
        //Esta es una interface para guardar y editar las tareas
        Trabajo Save(Trabajo trabajo);
    }
}
