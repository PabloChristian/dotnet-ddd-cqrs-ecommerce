using ECommerce.Core.Service.DomainObject.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalogo.Domain.Interface
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);
        Task<IEnumerable<Departamento>> ObterFamilias();

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);

        void Adicionar(Departamento categoria);
        void Atualizar(Departamento categoria);
    }
}
