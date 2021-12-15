using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using NSE.Pedidos.API.Application.Events;
using NSE.Pedidos.API.Application.Mappers;
using NSE.Pedidos.Domain.Pedidos.Entities;
using NSE.Pedidos.Domain.Pedidos.Repository;
using NSE.Pedidos.Domain.Vouchers.Repository;
using NSE.Pedidos.Domain.Vouchers.Specs;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Pedidos.API.Application.Commands.Handlers
{
    public class PedidoCommandHandler : CommandHandler,
        IRequestHandler<AdicionarPedidoCommand, ValidationResult>
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoCommandHandler(IVoucherRepository voucherRepository, IPedidoRepository pedidoRepository)
        {
            _voucherRepository = voucherRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarPedidoCommand message, CancellationToken cancellationToken)
        {
            if(!message.EhValido()) return message.ValidationResult;

            var pedido = MapearPedido(message);

            if (!await AplicarVoucher(message, pedido)) return ValidationResult;

            if (!ValidarPedido(pedido)) return ValidationResult;

            if (!ProcessarPagamento(pedido)) return ValidationResult;

            pedido.AutorizarPedido();

            pedido.AdicionarEvento(new PedidoRealizadoEvent(pedido.Id, pedido.ClienteId));

            _pedidoRepository.Adicionar(pedido);

            return await PersistirDados(_pedidoRepository.UnitOfWork);
        }


        private Pedido MapearPedido(AdicionarPedidoCommand message)
        {
            var endereco = EnderecoMapper.ParaEndereco(message.Endereco);

            var pedido = new Pedido(
                    message.ClienteId,
                    message.ValorTotal,
                    message.PedidoItems.Select(PedidoItemMapper.ParaPedidoItem).ToList(),
                    message.VoucherUtilizado,
                    message.Desconto
                );

            pedido.AtribuirEndereco(endereco);
            return pedido;
        }

        private async Task<bool> AplicarVoucher(AdicionarPedidoCommand message, Pedido pedido)
        {
            if(!message.VoucherUtilizado) return true;

            var voucher = await _voucherRepository.ObterVoucherPorCodigo(message.VoucherCodigo);
            if(voucher == null)
            {
                AdicionarErro("O voucher informado não existe");
                return false;
            }

            var voucherValidation = new VoucherValidation().Validate(voucher);
            if (!voucherValidation.IsValid)
            {
                voucherValidation.Errors.ToList().ForEach(err => AdicionarErro(err.ErrorMessage));
                return false;
            }

            pedido.AtribuirVoucher(voucher);
            voucher.DebitarQuantidade();

            _voucherRepository.Atualizar(voucher);

            return true;
        }

        private bool ValidarPedido(Pedido pedido)
        {
            var pedidoValorOriginal = pedido.ValorTotal;
            var pedidoDesconto = pedido.Desconto;

            pedido.CalcularValorPedido();

            if(pedido.ValorTotal != pedidoValorOriginal)
            {
                AdicionarErro("O valor total do pedido não confere com o cálculo do pedido");
                return false;
            }

            if(pedido.Desconto != pedidoDesconto)
            {
                AdicionarErro("O valor total não confere com o calculo do pedido");
                return false;
            }

            return true;
        }

        public bool ProcessarPagamento(Pedido pedido) => true;
    }
}
