using NSE.Pedidos.API.Application.DTO;
using NSE.Pedidos.Domain.Pedidos.Entities;


namespace NSE.Pedidos.API.Application.Mappers
{
    public class EnderecoMapper
    {
        public static EnderecoDTO ParaEnderecoDTO(Endereco endereco) =>
            new EnderecoDTO()
            {
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cep = endereco.Cep,
                Cidade = endereco.Cidade,
                Estado = endereco.Estado
            };

        public static Endereco ParaEndereco(EnderecoDTO enderecoDTO) =>
             new Endereco
             {
                 Logradouro = enderecoDTO.Logradouro,
                 Numero = enderecoDTO.Numero,
                 Complemento = enderecoDTO.Complemento,
                 Bairro = enderecoDTO.Bairro,
                 Cep = enderecoDTO.Cep,
                 Cidade = enderecoDTO.Cidade,
                 Estado = enderecoDTO.Estado
             };
    }
}
