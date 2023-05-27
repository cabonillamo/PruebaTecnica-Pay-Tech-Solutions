using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceTarea : IServiceTarea
    {
        public IEnumerable<Trabajo> GetAlCompletadasl()
        {
            IRepositoryTarea repositoryTarea = new RepositoryTarea();
            return repositoryTarea.GetAlCompletadasl();
        }

        public IEnumerable<Trabajo> GetAll()
        {
            IRepositoryTarea repositoryTarea = new RepositoryTarea();
            return repositoryTarea.GetAll();
        }

        public IEnumerable<Trabajo> GetAllPendientes()
        {
            IRepositoryTarea repositoryTarea = new RepositoryTarea();
            return repositoryTarea.GetAllPendientes();
        }

        public Trabajo GetById(int id)
        {
            IRepositoryTarea repositoryTarea = new RepositoryTarea();
            return repositoryTarea.GetById(id);
        }

        public Trabajo Save(Trabajo trabajo)
        {
            IRepositoryTarea repositoryTarea = new RepositoryTarea();
            return repositoryTarea.Save(trabajo);
        }
    }
}
