using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryBorrado
    {
        //Esta es un interface para traer todos los Borrado
        IEnumerable<Borrado_Logico> GetBorrado();
    }
}
