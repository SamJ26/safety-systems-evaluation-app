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

        // Route: api/safetyFunction
        [HttpGet]
        [SwaggerOperation(OperationId = "SafetyFunctionGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<SafetyFunctionListModel>>> GetAll(int accessPointId = 0)
        {
            ICollection<SafetyFunctionListModel> data = new List<SafetyFunctionListModel>();
            if (accessPointId == 0)
                data = await safetyFunctionFacade.GetAllAsync(accessPointId);
            else
                data = await safetyFunctionFacade.GetAllAsync();
            return Ok(data);
        }

        // Route: api/safetyFunction/pl
        [HttpPost("pl")]
        [SwaggerOperation(OperationId = "SafetyFunctionCreatePL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create(SafetyFunctionDetailModelPL newModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var id = await safetyFunctionFacade.CreateAsync(newModel);
            return Ok(id);
        }

        // Route: api/safetyFunction/sil
        [HttpPost("sil")]
        [SwaggerOperation(OperationId = "SafetyFunctionCreateSIL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create(SafetyFunctionDetailModelSIL newModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var id = await safetyFunctionFacade.CreateAsync(newModel);
            return Ok(id);
        }
    }
}
