using TaxStrategy.Application.ViewModels;
using TaxStrategy.Domain.Entities;

namespace TaxStrategy.Application.Interface
{
    public interface ITaxStrategyPaiService
    {
        TaxStrategyPaiViewModel GetAll();
        TaxStrategyPaiViewModel GetByEstado(string estado);
        TaxStrategyPaiViewModel Add(TaxStrategyPai model);
        TaxStrategyPaiViewModel Update(int id);
        TaxStrategyPaiViewModel Delete(int id);
    }
}
