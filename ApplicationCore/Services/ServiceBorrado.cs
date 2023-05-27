using Infraestructure.Model;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceBorrado : IServiceBorrado
    {
        public IEnumerable<Borrado_Logico> GetBorrado()
        {
            IRepositoryBorrado repositoryBorrado = new RepositoryBorrado();
            return repositoryBorrado.GetBorrado();
        }
    }
}
