using MediatR;
using Microsoft.EntityFrameworkCore;
using Reto.IPersistencia.Promocion;
using Reto.Persistencia;
using Reto.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reto.Infraestructura.Promocion.Command
{
    public class CanjearCodigo
    {
        public class Request : IRequest<MessageJson<string>>
        {
            [Required]
            public string codigo { get; set; }


        }

        public class CommandHandle : IRequestHandler<Request, MessageJson<string>>
        {

            private readonly IPromocionReadDb read;
            private readonly IPromocionWriteDb write;

            public CommandHandle(IPromocionReadDb read_, IPromocionWriteDb write_)
            {
                read = read_;
                write = write_;
            }


            async Task<MessageJson<string>> IRequestHandler<Request, MessageJson<string>>.Handle(Request request, CancellationToken cancellationToken)
            {

                var exists = await read.ExistePorCodigo(request.codigo, "GENERADO");
                if (exists.Count == 0)
                    throw new ManageException(System.Net.HttpStatusCode.BadRequest, "No existe el codigo para canjear y/o Ya ha sido canjeado");
                var promocion = exists.FirstOrDefault();
                promocion.estado = "CANJEADO";
                promocion.fechaCanje = DateTime.Now;

                string res = await write.ActualizarPromocion(promocion);
                if (res is "ok")
                    return new MessageJson<string> { mensaje = "ok", objeto = "Promocion canjeada" };
                else
                    throw new ManageException(System.Net.HttpStatusCode.BadRequest, res);

            }
        }
    }
}
