using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxStrategy.Domain.Entities;

namespace TaxStrategy.Domain.Interfaces
{
    public interface ITaxStrategyPaiRepository
    {
        IEnumerable<TaxStrategyPai> GetAll();
        IEnumerable<TaxStrategyPai> GetByEstado(string estado);
        TaxStrategyPai GetById(int id);
        TaxStrategyPai Add(TaxStrategyPai model);
        TaxStrategyPai Update(TaxStrategyPai model);
        bool Delete(TaxStrategyPai model);
    }
}
