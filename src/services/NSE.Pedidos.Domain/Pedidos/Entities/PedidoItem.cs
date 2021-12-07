using System;

namespace NSE.Pedidos.Domain.Pedidos.Entities
{
    public class PedidoItem
    {
        public PedidoItem(Guid produtoId, string nome, int quantidade,
                            decimal valorUnitario, string produtoImagem)
        {
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            ProdutoImagem = produtoImagem;
        }

        protected PedidoItem() { }

        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome{ get; private set; }
        public int Quantidade{ get; private set; }
        public decimal ValorUnitario{ get; private set; }
        public string ProdutoImagem{ get; private set; }

        public Pedido Pedido { get; set; }

        internal decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }
    }
}
