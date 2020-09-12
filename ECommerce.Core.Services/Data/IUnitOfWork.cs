using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Service.DomainObject.Interface
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
