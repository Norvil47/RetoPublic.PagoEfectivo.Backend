using Microsoft.EntityFrameworkCore;
using Reto.Entidades;
using System;

namespace Reto.Persistencia
{
    public class ModeloContext : DbContext
    {

        public DbSet<Entidades.Promocion> Promocion { get; set; }
      

        public ModeloContext(DbContextOptions<ModeloContext> options)
         : base(options)
        {

        }
    }
}
