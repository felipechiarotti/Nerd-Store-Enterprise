﻿using NSE.Core.Specification;
using NSE.Pedidos.Domain.Vouchers.Entities;
using System;
using System.Linq.Expressions;

namespace NSE.Pedidos.Domain.Vouchers.Specs
{
    public class VoucherDataSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression()
        {
            return voucher => voucher.DataValidade >= DateTime.Now;
        }
    }

    public class VoucherQuantidadeSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression()
        {
            return voucher => voucher.Quantidade > 0;
        }
    }

    public class VoucherAtivoSpecification : Specification<Voucher>
    {
        public override Expression<Func<Voucher, bool>> ToExpression()
        {
            return voucher => voucher.Ativo && !voucher.Utilizado;
        }
    }
}
