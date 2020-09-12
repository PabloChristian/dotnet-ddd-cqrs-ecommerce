using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Service.DomainObject.Interface
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
