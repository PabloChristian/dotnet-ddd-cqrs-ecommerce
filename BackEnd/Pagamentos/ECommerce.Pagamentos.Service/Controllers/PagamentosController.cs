using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce.Pagamentos.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagamentosController : ControllerBase
    {
        private readonly ILogger<PagamentosController> _logger;

        public PagamentosController(ILogger<PagamentosController> logger)
        {
            _logger = logger;
        }
    }
}
