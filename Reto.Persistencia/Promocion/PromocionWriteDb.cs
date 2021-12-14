using Reto.IPersistencia.Promocion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Persistencia.Promocion
{
    public class PromocionWriteDb:IPromocionWriteDb
    {
        private readonly ModeloContext db;
        public PromocionWriteDb(ModeloContext db_)
        {
            db = db_;
        }
        public async Task<string> CrearPromocion(Entidades.Promocion obj)
        {
            try
            {
                await db.AddAsync(obj);
                await db.SaveChangesAsync();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
          
        }
        public async Task<string> ActualizarPromocion(Entidades.Promocion obj)
        {
            try
            {
                db.Update(obj);
                await db.SaveChangesAsync();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
          
        }
    }
}
