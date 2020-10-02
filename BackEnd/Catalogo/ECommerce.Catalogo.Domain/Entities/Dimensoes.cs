using ECommerce.Core.Service.DomainObject.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal _altura, decimal _largura, decimal _profundidade)
        {
            Validacao.ValidarSeMenorQue(_altura, 1, "O campo Altura não pode ser menor ou igual a 0");
            Validacao.ValidarSeMenorQue(_largura, 1, "O campo Largura não pode ser menor ou igual a 0");
            Validacao.ValidarSeMenorQue(_profundidade, 1, "O campo Profundidade não pode ser menor ou igual a 0");

            Altura = _altura;
            Largura = _largura;
            Profundidade = _profundidade;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}
