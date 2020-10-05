using ECommerce.Catalogo.Domain;
using ECommerce.Core.Service.DomainObject.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalogo.Infrastructure.Repository.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
    }
}
