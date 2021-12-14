using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reto.Infraestructura.Promocion.Command;
using Reto.Infraestructura.Promocion.Query;
using Reto.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionController : baseController
    {
        private IMediator _mediator;

        public PromocionController(IMediator _mediator_)
        {
            _mediator = _mediator_;
        }

        [HttpPost]
        [Route("GenerarCodigo")]
        public async Task<MessageJson<Entidades.Promocion>> GenerarCodigo([FromBody] GenerarCodigo.Request obj)
        {
            return await _mediator.Send(obj);
        }
        [HttpPost]
        [Route("CanjeraCodigo")]
        public async Task<MessageJson<string>> CanjearCodigo([FromBody] CanjearCodigo.Request obj)
        {
            return await _mediator.Send(obj);
        }
        [HttpGet]
        public async Task<List<Entidades.Promocion>> ListarCodigos()
        {
            var obj = new ListarCodigos.Request();
            return await _mediator.Send(obj);
        }
    }
}
