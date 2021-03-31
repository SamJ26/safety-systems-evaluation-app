using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSEA.Api.Extensions;
using SSEA.BL.Facades;
using SSEA.BL.Models.SafetyEvaluation.MainModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEA.Api.Controllers
{
    [Authorize]
    [Route("api/subsystem")]
    [ApiController]
    public class SubsystemController : ControllerBase
    {
        private readonly SubsystemFacade subsystemFacade;

        public SubsystemController(SubsystemFacade subsystemFacade)
        {
            this.subsystemFacade = subsystemFacade;
        }

        // GET: api/subsystem/pl
        [HttpGet("pl/{id}")]
        [SwaggerOperation(OperationId = "SubsystemGetAllPL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<SubsystemListModelPL>>> GetAllPLAsync([FromQuery] int stateId,
                                                                                         [FromQuery] int typeOfSubsystemId,
                                                                                         [FromQuery] int operationPrincipleId,
                                                                                         [FromQuery] int categoryId,
                                                                                         [FromQuery] int performanceLevelId)
        {
            var data = await subsystemFacade.GetAllPLAsync(stateId, typeOfSubsystemId, operationPrincipleId, categoryId, performanceLevelId);
            return Ok(data);
        }

        // GET: api/subsystem/sil
        [HttpGet("sil/{id}")]
        [SwaggerOperation(OperationId = "SubsystemGetAllSIL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<SubsystemListModelSIL>>> GetAllSILAsync([FromQuery] int stateId,
                                                                                           [FromQuery] int typeOfSubsystemId,
                                                                                           [FromQuery] int operationPrincipleId,
                                                                                           [FromQuery] int architectureId,
                                                                                           [FromQuery] int silId)
        {
            var data = await subsystemFacade.GetAllSILAsync(stateId, typeOfSubsystemId, operationPrincipleId, architectureId, silId);
            return Ok(data);
        }

        // GET: api/subsystem/pl/detail/{id}
        [HttpGet("pl/detail/{id}")]
        [SwaggerOperation(OperationId = "SubsystemGetByIdPL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubsystemDetailModelPL>> GetByIdPLAsync(int id)
        {
            var data = await subsystemFacade.GetByIdPLAsync(id);
            if (data is null)
                return NotFound();
            return Ok(data);
        }

        // GET: api/subsystem/sil/detail/{id}
        [HttpGet("sil/detail/{id}")]
        [SwaggerOperation(OperationId = "SubsystemGetByIdSIL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubsystemDetailModelSIL>> GetByIdSILAsync(int id)
        {
            var data = await subsystemFacade.GetByIdSILAsync(id);
            if (data is null)
                return NotFound();
            return Ok(data);
        }

        // POST: api/subsystem/pl
        [HttpPost("pl")]
        [Authorize(Roles = "Administrator, NormalUser")]
        [SwaggerOperation(OperationId = "SubsystemCreatePL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SubsystemCreationResponseModel>> CreateAsync(SubsystemDetailModelPL model, int safetyFunctionId = 0)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            SubsystemCreationResponseModel response = await subsystemFacade.CreateAsync(model, userId, safetyFunctionId);
            return Ok(response);
        }

        //// POST: api/subsystem/sil
        //[HttpPost("sil")]
        //[SwaggerOperation(OperationId = "SubsystemCreateSIL")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<int>> CreateAsync(SubsystemDetailModelSIL model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();
        //    var userId = this.GetUserIdFromHttpContext();
        //    var id = await subsystemFacade.CreateAsync(model, userId);
        //    return Ok(id);
        //}
    }
}
