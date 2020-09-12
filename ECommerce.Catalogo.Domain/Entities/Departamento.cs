﻿using ECommerce.Core.Service.DomainObject;
using ECommerce.Core.Service.DomainObject.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Catalogo.Domain
{
    public class Departamento : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        // EF Relation
        public ICollection<Produto> Produtos { get; set; }

        protected Departamento() { }

        public Departamento(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacao.ValidarSeVazio(Nome, "O campo Nome do departamento não pode estar vazio");
            Validacao.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
        }
    }
}