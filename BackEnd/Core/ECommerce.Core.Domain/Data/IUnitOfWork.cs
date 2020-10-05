using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Domain.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
