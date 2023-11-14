using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaxStrategy.Domain.Entities;

namespace TaxStrategy.Application.ViewModels
{
    public class TaxStrategyPaiViewModel
    {
        public IEnumerable<TaxStrategyPai>? _GetTaxStrategyPai { get; set; }
        public TaxStrategyPai? _TaxStrategyPai { get; set; }
        public bool _DeleteTaxStrategyPai { get; set; }
        public string? _MensagemErro { get; set; }
    }
}
