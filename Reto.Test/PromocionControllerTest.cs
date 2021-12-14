using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reto.Api.Controllers;
using Reto.Infraestructura.Promocion.Command;
using System.Threading.Tasks;

namespace Reto.Test
{
    [TestClass]
    public class PromocionControllerTest
    {
      
        [TestMethod]
        public async Task GenerarCodigoAsync()
        {
            var _mediator = new Mock<IMediator>();
            var controller = new PromocionController(_mediator.Object);
            var response = await controller.GenerarCodigo(new GenerarCodigo.Request { email = "djuan@gmail.com", nombre = "Juan" });
            Assert.AreEqual("ok",response.mensaje);                        
        }

        [TestMethod]
        public async Task CanjearCodigoAsync()
        {
            var _mediator = new Mock<IMediator>();
            var controller = new PromocionController(_mediator.Object);
            var response = await controller.CanjearCodigo(new CanjearCodigo.Request { codigo = "xxxx" });
            Assert.AreEqual("ok", response.mensaje);

        }
       
    }
}
