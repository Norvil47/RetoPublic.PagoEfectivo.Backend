using MediatR;
using Microsoft.EntityFrameworkCore;
using Reto.Infraestructura.Util;
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
    public class GenerarCodigo
    {
        public class Request : IRequest<MessageJson<Entidades.Promocion>>
        {
            [Required]
            public string nombre { get; set; }
            [Required]
            public string email { get; set; }


        }

        public class CommandHandle : IRequestHandler<Request, MessageJson<Entidades.Promocion>>
        {

            private readonly IPromocionReadDb read;
            private readonly IPromocionWriteDb write;

            public CommandHandle(IPromocionReadDb read_, IPromocionWriteDb write_)
            {
                read = read_;
                write = write_;
            }


            async Task<MessageJson<Entidades.Promocion>> IRequestHandler<Request, MessageJson<Entidades.Promocion>>.Handle(Request request, CancellationToken cancellationToken)
            {

                var exists = await read.ExistePorEmail(request.email);

                if (exists)
                    throw new ManageException(System.Net.HttpStatusCode.BadRequest, "Ya se ha generado un codigo con el email indicado");


                var codigo = Funciones.GenerarCodigoPromocion(request.email.Length / 2);
                codigo += $"-{request.email.Split("@")[0]}";

                var promocion = new Entidades.Promocion();
                promocion.email = request.email;
                promocion.nombreUsuario = request.nombre;
                promocion.fechaCreacion = DateTime.Now;
                promocion.codigo = codigo;
                promocion.estado = "GENERADO";


                string res = await write.CrearPromocion(promocion);
                if (res is "ok")
                    return new MessageJson<Entidades.Promocion> { mensaje = "ok", objeto = promocion };
                else
                    throw new ManageException(System.Net.HttpStatusCode.BadRequest, res);


            }
        }
    }
}
