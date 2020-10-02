using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce.Catalogo.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : ControllerBase
    {
        private readonly ILogger<CatalogoController> _logger;

        public CatalogoController(ILogger<CatalogoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Catalogo> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Catalogo
            {

            })
            .ToArray();
        }
    }
}
