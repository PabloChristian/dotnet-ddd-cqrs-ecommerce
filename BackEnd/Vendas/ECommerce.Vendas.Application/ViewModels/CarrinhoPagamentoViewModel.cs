using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Vendas.Application.ViewModels
{
    public class CarrinhoPagamentoViewModel
    {
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }
    }
}
