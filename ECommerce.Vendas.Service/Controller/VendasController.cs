using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce.Vendas.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : ControllerBase
    {

        private readonly ILogger<VendasController> _logger;

        public VendasController(ILogger<VendasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Vendas> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Vendas
            {

            })
            .ToArray();
        }
    }
}
