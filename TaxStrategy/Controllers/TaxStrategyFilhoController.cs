using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxStrategy.Application.Interface;
using TaxStrategy.Application.ViewModels;
using TaxStrategy.Domain.Entities;

namespace TaxStrategyAPI.Web.Mvc.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxStrategyFilhoController : ControllerBase
    {
        private readonly ITaxStrategyFilhoService _service;

        public TaxStrategyFilhoController(ITaxStrategyFilhoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<TaxStrategyFilhoViewModel> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("GetByEstado/{estado}")]
        public ActionResult<TaxStrategyFilhoViewModel> GetByEstado(string estado)
        {
            return _service.GetByEstado(estado);
        }

        [HttpPost]
        public ActionResult<TaxStrategyFilhoViewModel> Add([FromBody] TaxStrategyFilho model)
        {
            return _service.Add(model);
        }

        [HttpPut]
        public ActionResult<TaxStrategyFilhoViewModel> Update(int id)
        {
            return _service.Update(id);
        }
    }
}
