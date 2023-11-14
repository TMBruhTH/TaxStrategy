using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxStrategy.Application.Interface;
using TaxStrategy.Application.ViewModels;
using TaxStrategy.Domain.Entities;

namespace TaxStrategyAPI.Web.Mvc.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxStrategyPaiController : ControllerBase
    {
        private readonly ITaxStrategyPaiService _service;

        public TaxStrategyPaiController(ITaxStrategyPaiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<TaxStrategyPaiViewModel> GetAll() 
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("GetByEstado/{estado}")]
        public ActionResult<TaxStrategyPaiViewModel> GetByEstado(string estado)
        {
            return _service.GetByEstado(estado);
        }

        [HttpPost]
        public ActionResult<TaxStrategyPaiViewModel> Add([FromBody] TaxStrategyPai model)
        {
            return _service.Add(model);
        }

        [HttpPut]
        public ActionResult<TaxStrategyPaiViewModel> Update(int id)
        {
            return _service.Update(id);
        }

        [HttpDelete]
        public ActionResult<TaxStrategyPaiViewModel> Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
