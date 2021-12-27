using NSE.Pagamentos.API.Models;
using NSE.Pagamentos.NerdsPag;
using System;

namespace NSE.Pagamentos.API.Mappers
{
    public class TransactionMapper
    {
        public static Transacao ParaTransacao(Transaction transaction) =>
            new Transacao()
            {
                Id = Guid.NewGuid(),
                Status = (StatusTransacao)transaction.Status,
                ValorTotal = transaction.Amount,
                BandeiraCartao = transaction.CardBrand,
                CodigoAutorizacao = transaction.AuthorizationCode,
                CustoTransacao = transaction.Cost,
                DataTransacao = transaction.TransactionDate,
                NSU = transaction.Nsu,
                TID = transaction.Tid,
            };
    }
}
