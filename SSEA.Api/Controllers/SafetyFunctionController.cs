using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSEA.BL.Facades;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(OperationId = "SafetyFunctionGetAll")]
        public ActionResult<IEnumerable<SafetyFunctionListModel>> GetAll()
        {
            return Ok();
        }

        // api/safetyFunction/pl/{id}
        [HttpGet("pl/{id}")]
        [SwaggerOperation(OperationId = "SafetyFunctionGetByIdPL")]
        public ActionResult<SafetyFunctionDetailModelPL> GetByIdPL(int id)
        {
            return Ok();
        }

        // api/safetyFunction/sil/{id}
        [HttpGet("sil/{id}")]
        [SwaggerOperation(OperationId = "SafetyFunctionGetByIdSIL")]
        public ActionResult<SafetyFunctionDetailModelSIL> GetByIdSIL(int id)
        {
            return Ok();
        }

        // api/safetyFunction/pl
        [HttpPost("pl")]
        [SwaggerOperation(OperationId = "SafetyFunctionCreatePL")]
        public ActionResult<int> Create(SafetyFunctionDetailModelPL newModel)
        {
            return Ok();
        }

        // api/safetyFunction/sil
        [HttpPost("sil")]
        [SwaggerOperation(OperationId = "SafetyFunctionCreateSIL")]
        public ActionResult<int> Create(SafetyFunctionDetailModelSIL newModel)
        {
            return Ok();
        }

        // api/safetyFunction/pl
        [HttpPut("pl")]
        [SwaggerOperation(OperationId = "SafetyFunctionUpdatePL")]
        public ActionResult<int> Update(SafetyFunctionDetailModelPL updatedModel)
        {
            return Ok();
        }

        // api/safetyFunction/sil
        [HttpPut("sil")]
        [SwaggerOperation(OperationId = "SafetyFunctionUpdateSIL")]
        public ActionResult<int> Update(SafetyFunctionDetailModelSIL updatedModel)
        {
            return Ok();
        }

        // api/safetyFunction/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(OperationId = "SafetyFunctionDelete")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
