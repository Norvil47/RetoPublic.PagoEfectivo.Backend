using MediatR;
using Microsoft.EntityFrameworkCore;
using Reto.IPersistencia.Promocion;
using Reto.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reto.Infraestructura.Promocion.Query
{
  public  class ListarCodigos
    {
        public class Request : IRequest<List<Entidades.Promocion>>
        {
           
        }

        public class CommandHandle : IRequestHandler<Request, List<Entidades.Promocion>>
        {

            private readonly IPromocionReadDb read;

            public CommandHandle(IPromocionReadDb read_)
            {
                read = read_;
            }
            async Task<List<Entidades.Promocion>> IRequestHandler<Request, List<Entidades.Promocion>>.Handle(Request request, CancellationToken cancellationToken)
            {

                return await read.ListarPromociones();
            }
        }
    }
}
