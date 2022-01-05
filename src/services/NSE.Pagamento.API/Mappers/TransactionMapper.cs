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

        public static Transaction ParaTransaction(Transacao transacao, NerdsPagService nerdsPagService) =>
         new Transaction(nerdsPagService)
         {
             Status = (TransactionStatus)transacao.Status,
             Amount = transacao.ValorTotal,
             CardBrand = transacao.BandeiraCartao,
             AuthorizationCode = transacao.CodigoAutorizacao,
             Cost = transacao.CustoTransacao,
             Nsu = transacao.NSU,
             Tid = transacao.TID
         };
    }
}

