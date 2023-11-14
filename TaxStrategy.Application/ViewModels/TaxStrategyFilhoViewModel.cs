using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxStrategy.Domain.Entities;

namespace TaxStrategy.Application.ViewModels
{
    public class TaxStrategyFilhoViewModel
    {
        public IEnumerable<TaxStrategyFilho>? _GetTaxStrategyFilho { get; set; }
        public TaxStrategyFilho? _TaxStrategyFilho { get; set; }
        public string? _MensagemErro { get; set; }
    }
}
