using NSE.Pedidos.API.Application.DTO;
using NSE.Pedidos.Domain.Pedidos.Entities;

namespace NSE.Pedidos.API.Application.Mappers
{
    public class PedidoItemMapper
    {
        public static PedidoItemDTO ParaPedidoItemDTO(PedidoItem item) =>
            new PedidoItemDTO()
            {
                Nome = item.Nome,
                Imagem = item.ProdutoImagem,
                Quantidade = item.Quantidade,
                Valor = item.ValorUnitario,
                PedidoId = item.PedidoId,
                ProdutoId = item.ProdutoId
            };

        public static PedidoItem ParaPedidoItem(PedidoItemDTO itemDTO) =>
            new PedidoItem(itemDTO.ProdutoId, itemDTO.Nome, itemDTO.Quantidade, itemDTO.Valor, itemDTO.Imagem);

    }
}
