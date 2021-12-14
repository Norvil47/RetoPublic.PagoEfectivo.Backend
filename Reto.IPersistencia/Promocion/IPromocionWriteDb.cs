using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.IPersistencia.Promocion
{
    public interface IPromocionWriteDb
    {
       Task<string> CrearPromocion(Entidades.Promocion obj);
         Task<string> ActualizarPromocion(Entidades.Promocion obj);

    }
}
