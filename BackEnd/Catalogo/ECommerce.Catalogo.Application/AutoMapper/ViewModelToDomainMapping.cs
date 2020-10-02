using AutoMapper;
using ECommerce.Catalogo.Application.ViewModel;
using ECommerce.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<ProdutoViewModel, Produto>()
               .ConstructUsing(p =>
                   new Produto(p.Nome, p.Descricao, p.Ativo,
                       p.Valor, p.CategoriaId, p.DataCadastro,
                       p.Imagem, new Dimensoes(p.Altura, p.Largura, p.Profundidade)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}
