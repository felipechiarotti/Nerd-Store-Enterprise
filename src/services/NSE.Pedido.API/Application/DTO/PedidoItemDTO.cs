using NSE.Pedidos.Domain.Pedidos.Entities;
using System;

namespace NSE.Pedidos.API.Application.DTO
{
    public class PedidoItemDTO
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public int Quantidade{ get; set; }
        public decimal Valor{ get; set; }
        public Guid PedidoId{ get; set; }
        public Guid ProdutoId { get; set; }


    }
}
