using Infraestructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceBorrado
    {
        //Esta es un interface para traer todos los Borrado
        IEnumerable<Borrado_Logico> GetBorrado();
    }
}
