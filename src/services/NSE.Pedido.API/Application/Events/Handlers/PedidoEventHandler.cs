
using MediatR;
using NSE.Core.Messages.Integration;
using NSE.MessageBus;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Pedidos.API.Application.Events.Handlers
{
    public class PedidoEventHandler : INotificationHandler<PedidoRealizadoEvent>
    {
        private readonly IMessageBus _bus;

        public PedidoEventHandler(IMessageBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(PedidoRealizadoEvent message, CancellationToken cancellationToken)
        {
            await _bus.PublisAsync(new PedidoRealizadoIntegrationEvent(message.ClienteId));
        }
    }
}
