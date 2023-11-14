using TaxStrategy.Application.Interface;
using TaxStrategy.Application.ViewModels;
using TaxStrategy.Domain.Entities;
using TaxStrategy.Domain.Interfaces;

namespace TaxStrategy.Application.Services
{
    public class TaxStrategyPaiService : ITaxStrategyPaiService
    {
        private readonly ITaxStrategyPaiRepository _repository;
        private readonly ITaxStrategyFilhoRepository _filhoRepository;

        public TaxStrategyPaiService(ITaxStrategyPaiRepository repository, ITaxStrategyFilhoRepository filhoRepository)
        {
            _repository = repository;
            _filhoRepository = filhoRepository;
        }
        #region [GetAll]
        public TaxStrategyPaiViewModel GetAll()
        {
            return new TaxStrategyPaiViewModel { _GetTaxStrategyPai = _repository.GetAll() };
        }
        #endregion

        #region [GetByEstado]
        public TaxStrategyPaiViewModel GetByEstado(string estado)
        {
            return new TaxStrategyPaiViewModel { _GetTaxStrategyPai = _repository.GetByEstado(estado) };
        }
        #endregion

        #region [Add]
        public TaxStrategyPaiViewModel Add(TaxStrategyPai model)
        {
            if (model.Id > 0)
            {
                model.Id = 0;
            }

            if (!model.Estado.ToLower().Contains("pendente"))
            {
                model.Estado = "pendente";
            }

            model.DthCricao = DateTime.Now;
            model.DthConclusao = null;

            if (model.Descricao.Length > 500)
            {
                return new TaxStrategyPaiViewModel 
                {
                    _MensagemErro = "Atenção!! Descrição com mais de 500 caracteres!"
                };
            }

            return new TaxStrategyPaiViewModel { _TaxStrategyPai = _repository.Add(model) };
        }
        #endregion

        #region [Delete]
        public TaxStrategyPaiViewModel Delete(int id)
        {
            var model = _repository.GetById(id);
            if (model == null)
            {
                return new TaxStrategyPaiViewModel { _MensagemErro = "Atenção!! Não existe o registro para deletar!" };
            }

            return new TaxStrategyPaiViewModel { _DeleteTaxStrategyPai = _repository.Delete(model) };
        }
        #endregion

        #region [Update]
        public TaxStrategyPaiViewModel Update(int id)
        {
            var model = _repository.GetById(id);

            if (model == null)
            {
                return new TaxStrategyPaiViewModel { _MensagemErro = "Atenção!! Não existe o registro para atualização!" };
            }

            var lista = _filhoRepository.GetByIdPai(model.Id);

            if (lista.Any(x => x.Estado.ToLower().Trim() != "concluída"))
            {
                return new TaxStrategyPaiViewModel { _MensagemErro = "Atenção!! Não foi possível alterar o estado da tarefa. Verifique o estado das tarefas filhas!" };
            }

            switch (model.Estado.ToLower().Trim())
            {
                case "pendente":
                    model.Estado = "em andamento";
                    break;
                case "em andamento":
                    model.Estado = "concluída";
                    model.DthConclusao = DateTime.Now;
                    break;
                default:
                    model.Estado = "concluída";
                    break;
            }

            return new TaxStrategyPaiViewModel { _TaxStrategyPai = _repository.Update(model) };
        }
        #endregion

    }
}
