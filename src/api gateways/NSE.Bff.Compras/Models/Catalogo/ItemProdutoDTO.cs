﻿using System;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Bff.Compras.Models.Catalogo
{
    public class ItemProdutoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
