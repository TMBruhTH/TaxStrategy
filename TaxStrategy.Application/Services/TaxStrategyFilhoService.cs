using System.Reflection;
using TaxStrategy.Application.Interface;
using TaxStrategy.Application.ViewModels;
using TaxStrategy.Domain.Entities;
using TaxStrategy.Domain.Interfaces;

namespace TaxStrategy.Application.Services
{
    public class TaxStrategyFilhoService : ITaxStrategyFilhoService
    {
        private readonly ITaxStrategyFilhoRepository _repository;
        private readonly ITaxStrategyPaiRepository _paiRepository;

        public TaxStrategyFilhoService(ITaxStrategyFilhoRepository repository, ITaxStrategyPaiRepository paiRepository)
        {
            _repository = repository;
            _paiRepository = paiRepository;
        }

        #region [GetAll]
        public TaxStrategyFilhoViewModel GetAll()
        {
            return new TaxStrategyFilhoViewModel { _GetTaxStrategyFilho = _repository.GetAll() };
        }
        #endregion

        #region [GetByEstado]
        public TaxStrategyFilhoViewModel GetByEstado(string estado)
        {
            return new TaxStrategyFilhoViewModel { _GetTaxStrategyFilho = _repository.GetByEstado(estado) };
        }
        #endregion

        #region [Add]
        public TaxStrategyFilhoViewModel Add(TaxStrategyFilho model)
        {
            if(model.Id >  0) 
            {
                model.Id = 0;
            }

            if (!model.Estado.ToLower().Contains("pendente"))
            {
                model.Estado = "pendente";
            }

            if (model.Descricao.Length > 500)
            {
                return new TaxStrategyFilhoViewModel
                {
                    _MensagemErro = "Atenção!! Descrição com mais de 500 caracteres!"
                };
            }

            var retorno = _paiRepository.GetById(model.IdTaxStrategyPai);
            if (retorno == null)
            {
                return new TaxStrategyFilhoViewModel { _MensagemErro = "Atenção!! Não existe o registro pai para adição!" };
            }

            return new TaxStrategyFilhoViewModel { _TaxStrategyFilho = _repository.Add(model) };
        }
        #endregion

        #region [Update]
        public TaxStrategyFilhoViewModel Update(int id)
        {
            var model = _repository.GetById(id);

            switch (model.Estado.ToLower().Trim())
            {
                case "pendente":
                    model.Estado = "em andamento";
                    break;
                case "em andamento":
                    model.Estado = "concluída";
                    break;
                default:
                    model.Estado = "concluída";
                    break;
            }

            return new TaxStrategyFilhoViewModel { _TaxStrategyFilho = _repository.Update(model) };
        }
        #endregion
    }
}
