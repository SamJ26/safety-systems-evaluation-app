using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSEA.BL.Facades;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.Api.Controllers
{
    [Route("api/safetyFunction")]
    [ApiController]
    public class SafetyFunctionController : ControllerBase
    {
        private readonly SafetyFunctionFacade safetyFunctionFacade;

        public SafetyFunctionController(SafetyFunctionFacade safetyFunctionFacade)
        {
            this.safetyFunctionFacade = safetyFunctionFacade;
        }

        // api/safetyFunction
        [HttpGet]
        public ActionResult<IEnumerable<SafetyFunctionListModel>> GetAll()
        {
            return Ok();
        }

        // api/safetyFunction/pl/{id}
        [HttpGet("pl/{id}")]
        public ActionResult<SafetyFunctionDetailModelPL> GetByIdPL(int id)
        {
            return Ok();
        }

        // api/safetyFunction/sil/{id}
        [HttpGet("sil/{id}")]
        public ActionResult<SafetyFunctionDetailModelSIL> GetByIdSIL(int id)
        {
            return Ok();
        }

        // api/safetyFunction/pl
        [HttpPost("pl")]
        public ActionResult<int> Create(SafetyFunctionDetailModelPL newModel)
        {
            return Ok();
        }

        // api/safetyFunction/sil
        [HttpPost("sil")]
        public ActionResult<int> Create(SafetyFunctionDetailModelSIL newModel)
        {
            return Ok();
        }

        // api/safetyFunction/pl
        [HttpPut("pl")]
        public ActionResult<int> Update(SafetyFunctionDetailModelPL updatedModel)
        {
            return Ok();
        }

        // api/safetyFunction/sil
        [HttpPut("sil")]
        public ActionResult<int> Update(SafetyFunctionDetailModelSIL updatedModel)
        {
            return Ok();
        }

        // api/safetyFunction/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
