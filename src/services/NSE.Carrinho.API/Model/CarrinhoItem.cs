using FluentValidation;
using System;

namespace NSE.Carrinho.API.Model
{
    public class CarrinhoItem
    {
        public CarrinhoItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid CarrinhoId { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public CarrinhoCliente CarrinhoCliente { get; set; }


        internal void AssociarCarrinho(Guid carrinhoId)
        {
            this.CarrinhoId = carrinhoId;
        }

        internal void AdicionarUnidades(int quantidade)
        {
            Quantidade += quantidade;
        }

        internal void AtualizarUnidades(int quantidade)
        {
            Quantidade = quantidade;
        }
        internal decimal CalcularValor() => Quantidade * Valor;

        internal bool EhValido() => new ItemPedidoValidation().Validate(this).IsValid;

        public class ItemPedidoValidation : AbstractValidator<CarrinhoItem>
        {
            public ItemPedidoValidation()
            {
                RuleFor(c => c.ProdutoId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do Produto Inválido");

                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .WithMessage("O nome do produto não foi informado");

                RuleFor(c => c.Quantidade)
                    .GreaterThan(0)
                    .WithMessage(item => $"A quantidade mínima para {item.Nome} de um item é 1");

                RuleFor(c => c.Quantidade)
                    .GreaterThan(15)
                    .WithMessage(item => $"A quantidade máxima de {item.Nome} é 15");

                RuleFor(c => c.Valor)
                    .GreaterThan(0)
                    .WithMessage(item => $"O valor de {item.Nome} precisa ser maior que 0");
            }
        }
    }
}
