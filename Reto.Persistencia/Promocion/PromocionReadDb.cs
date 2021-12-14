using Microsoft.EntityFrameworkCore;
using Reto.IPersistencia.Promocion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Persistencia.Promocion
{
   public class PromocionReadDb: IPromocionReadDb
    {
        private readonly ModeloContext db;
        public PromocionReadDb(ModeloContext db_)
        {
            db = db_;
        }
        public async Task<bool> ExistePorEmail(string filtro)
        {
           return await db.Promocion.Where(x => x.email == filtro.Trim()).AnyAsync();
        }
        public async Task<List<Entidades.Promocion>> ExistePorCodigo(string filtro, string estado)
        {
            return await db.Promocion.Where(x => x.codigo == filtro.Trim() && x.estado == estado).ToListAsync();
        }
        public async Task<List<Entidades.Promocion>> ListarPromociones()
        {
            return await db.Promocion.OrderBy(x => x.nombreUsuario).ToListAsync();
        }
    }
}
