using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Core.Service.DomainObject;
using ECommerce.Core.Service.DomainObject.Validation;

namespace ECommerce.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public Categoria Categoria { get; private set; }
        public SubCategoria SubCategoria { get; private set; }
        public SubCategoriaNivelDois SubCategoriaNivelDois { get; private set; }
        public Marca Marca { get; private set; }

        protected Produto() { }
        public Produto(string _nome, string _descricao, bool _ativo, decimal _valor, DateTime _dataCadastro, string _imagem, Dimensoes _dimensoes, Categoria _categoria, SubCategoria _subCategoria, SubCategoriaNivelDois _subCategoriaNivelDois)
        {
            Nome = _nome;
            Descricao = _descricao;
            Ativo = _ativo;
            Valor = _valor;
            DataCadastro = _dataCadastro;
            Imagem = _imagem;
            Dimensoes = _dimensoes;
            Categoria = _categoria;
            SubCategoria = _subCategoria;
            SubCategoriaNivelDois = _subCategoriaNivelDois;

            Validar();
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria _categoria)
        {
            Categoria = _categoria;
        }

        public void AlterarDescricao(string _descricao)
        {
            Validacao.ValidarSeVazio(_descricao, "O campo Descricao do produto não pode estar vazio");
            Descricao = _descricao;
        }

        public void DebitarEstoque(int _quantidade)
        {
            if (_quantidade < 0) _quantidade *= -1;
            if (!PossuiEstoque(_quantidade)) throw new DomainException("Estoque insuficiente");
            QuantidadeEstoque -= _quantidade;
        }

        public void ReporEstoque(int _quantidade)
        {
            QuantidadeEstoque += _quantidade;
        }

        public bool PossuiEstoque(int _quantidade)
        {
            return QuantidadeEstoque >= _quantidade;
        }

        public void Validar()
        {
            Validacao.ValidarSeVazio(Nome, "O campo Nome do produto não pode estar vazio");
            Validacao.ValidarSeVazio(Descricao, "O campo Descricao do produto não pode estar vazio");
            Validacao.ValidarSeMenorQue(Valor, 1, "O campo Valor do produto não pode se menor igual a 0");
            Validacao.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio");
        }
    }
}
