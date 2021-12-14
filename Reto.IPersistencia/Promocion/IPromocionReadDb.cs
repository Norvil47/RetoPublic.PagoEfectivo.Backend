using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.IPersistencia.Promocion
{
    public interface IPromocionReadDb
    {
        Task<bool> ExistePorEmail(string filtro);
       Task<List<Entidades.Promocion>> ExistePorCodigo(string filtro, string estado);
        Task<List<Entidades.Promocion>> ListarPromociones();
    }
}
