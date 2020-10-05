using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Service.DomainObject.Validation
{
    public class DomainException : Exception
    {
        public DomainException()
        { }

        public DomainException(string message) : base(message)
        { }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
