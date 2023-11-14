using TaxStrategy.Application.ViewModels;
using TaxStrategy.Domain.Entities;

namespace TaxStrategy.Application.Interface
{
    public interface ITaxStrategyFilhoService
    {
        TaxStrategyFilhoViewModel GetAll();
        TaxStrategyFilhoViewModel GetByEstado(string estado);
        TaxStrategyFilhoViewModel Add(TaxStrategyFilho model);
        TaxStrategyFilhoViewModel Update(int id);
    }
}
