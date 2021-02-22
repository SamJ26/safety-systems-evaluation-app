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
    [Route("api/subsystem")]
    [ApiController]
    public class SubsystemController : ControllerBase
    {
        private readonly SubsystemFacade subsystemFacade;

        public SubsystemController(SubsystemFacade subsystemFacade)
        {
            this.subsystemFacade = subsystemFacade;
        }

        // api/subsystem
        [HttpGet]
        [SwaggerOperation(OperationId = "SubsystemGetAll")]
        public ActionResult<IEnumerable<SubsystemListModel>> GetAll()
        {
            return Ok();
        }

        // api/subsystem/pl/{id}
        [HttpGet("pl/{id}")]
        [SwaggerOperation(OperationId = "SubsystemGetByIdPL")]
        public ActionResult<SubsystemDetailModelPL> GetByIdPL(int id)
        {
            return Ok();
        }

        // api/subsystem/sil/{id}
        [HttpGet("sil/{id}")]
        [SwaggerOperation(OperationId = "SubsystemGetByIdSIL")]
        public ActionResult<SubsystemDetailModelSIL> GetByIdSIL(int id)
        {
            return Ok();
        }

        // api/subsystem/pl
        [HttpPost("pl")]
        [SwaggerOperation(OperationId = "SubsystemCreatePL")]
        public ActionResult<int> Create(SubsystemDetailModelPL newModel)
        {
            return Ok();
        }

        // api/subsystem/sil
        [HttpPost("sil")]
        [SwaggerOperation(OperationId = "SubsystemCreateSIL")]
        public ActionResult<int> Create(SubsystemDetailModelSIL newModel)
        {
            return Ok();
        }

        // api/subsystem/pl
        [HttpPut("pl")]
        [SwaggerOperation(OperationId = "SubsystemUpdatePL")]
        public ActionResult<int> Update(SubsystemDetailModelPL updatedModel)
        {
            return Ok();
        }

        // api/subsystem/sil
        [HttpPut("sil")]
        [SwaggerOperation(OperationId = "SubsystemUpdateSIL")]
        public ActionResult<int> Update(SubsystemDetailModelSIL updatedModel)
        {
            return Ok();
        }

        // api/subsystem/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(OperationId = "SubsystemDelete")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
