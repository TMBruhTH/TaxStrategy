using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxStrategy.Domain.Entities;

namespace TaxStrategy.Domain.Interfaces
{
    public interface ITaxStrategyFilhoRepository
    {
        IEnumerable<TaxStrategyFilho> GetAll();
        TaxStrategyFilho GetById(int id);
        IEnumerable<TaxStrategyFilho> GetByEstado(string estado);
        IEnumerable<TaxStrategyFilho> GetByIdPai(int idPai);
        TaxStrategyFilho Add(TaxStrategyFilho model);
        TaxStrategyFilho Update(TaxStrategyFilho model);
    }
}
