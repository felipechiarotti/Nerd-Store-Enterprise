using FluentValidation;
using NSE.Core.Messages;
using NSE.Pedidos.API.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSE.Pedidos.API.Application.Commands
{
    public class AdicionarPedidoCommand : Command
    {
        public Guid ClienteId { get; set; }
        public decimal ValorTotal{ get; set; }
        public List<PedidoItemDTO> PedidoItems{ get; set; }

        public string VoucherCodigo{ get; set; }
        public bool VoucherUtilizado{ get; set; }
        public decimal Desconto{ get; set; }

        public EnderecoDTO Endereco{ get; set; }

        public string NumeroCartao{ get; set; }
        public string NomeCartao{ get; set; }
        public string ExpiracaoCartao{ get; set; }
        public string CvvCartao{ get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarPedidoValidation : AbstractValidator<AdicionarPedidoCommand>
    {
        public AdicionarPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.PedidoItems.Count())
                .GreaterThan(0)
                .WithMessage("O pedido deve ter pelo menos 1 item");

            RuleFor(c => c.ValorTotal)
                            .GreaterThan(0)
                            .WithMessage("Valor do Pedido inválido");

            RuleFor(c => c.NumeroCartao)
                            .CreditCard()
                            .WithMessage("Número do cartão inválido");

            RuleFor(c => c.NomeCartao)
                            .NotNull()
                            .WithMessage("Nome do portador do cartão inválido");

            RuleFor(c => c.CvvCartao.Length)
                            .GreaterThan(2)
                            .LessThan(5)
                            .WithMessage("O Código de Segurança do Cartão está incorreto");

            RuleFor(c => c.ExpiracaoCartao)
                            .NotNull()
                            .WithMessage("Data de expiração do cartão requerida");


        }
    }
}
