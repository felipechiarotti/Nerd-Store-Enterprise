
using NSE.Pedidos.API.Application.DTO;
using NSE.Pedidos.Domain.Pedidos.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NSE.Pedidos.API.Application.Mappers
{
    public class PedidoMapper
    {
        public static PedidoDTO ParaPedidoDTO(Pedido pedido)
        {
            var pedidoDTO = new PedidoDTO
            {
                Id = pedido.Id,
                Codigo = pedido.Codigo,
                Status = (int)pedido.PedidoStatus,
                Data = pedido.DataCadastro,
                ValorTotal = pedido.ValorTotal,
                Desconto = pedido.Desconto,
                VoucherUtilizado = pedido.VoucherUtilizado,
                PedidoItems = new List<PedidoItemDTO>(),
                Endereco = new EnderecoDTO()
            };

            pedidoDTO.PedidoItems = pedido.PedidoItems.Select(item => PedidoItemMapper.ParaPedidoItemDTO(item)).ToList();
            pedidoDTO.Endereco = EnderecoMapper.ParaEnderecoDTO(pedido.Endereco);

            return pedidoDTO;
        }
    }
}
