﻿using Microsoft.AspNetCore.Authorization;
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
    [Route("api/safetyFunction")]
    [ApiController]
    public class SafetyFunctionController : ControllerBase
    {
        private readonly SafetyFunctionFacade safetyFunctionFacade;

        public SafetyFunctionController(SafetyFunctionFacade safetyFunctionFacade)
        {
            this.safetyFunctionFacade = safetyFunctionFacade;
        }

        // GET: api/safetyFunction
        [HttpGet]
        [SwaggerOperation(OperationId = "SafetyFunctionGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<SafetyFunctionListModel>>> GetAllAsync([FromQuery] string name,
                                                                                          [FromQuery] int stateId = 0,
                                                                                          [FromQuery] int typeOfFunctionId = 0,
                                                                                          [FromQuery] int evaluationMethodId = 0)
        {
            var data = await safetyFunctionFacade.GetAllAsync(name, stateId, typeOfFunctionId, evaluationMethodId);
            return Ok(data);
        }

        // GET: api/safetyFunction/pl/{id}
        [HttpGet("pl/{id}")]
        [SwaggerOperation(OperationId = "SafetyFunctionGetByIdPL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SafetyFunctionDetailModelPL>> GetByIdPLAsync(int id)
        {
            var data = await safetyFunctionFacade.GetByIdPLAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        // GET: api/safetyFunction/sil/{id}
        [HttpGet("sil/{id}")]
        [SwaggerOperation(OperationId = "SafetyFunctionGetByIdSIL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SafetyFunctionDetailModelSIL>> GetByIdSILAsync(int id)
        {
            var data = await safetyFunctionFacade.GetByIdSILAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        // POST: api/safetyFunction/pl
        [HttpPost("pl")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "SafetyFunctionCreatePL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateAsync(SafetyFunctionDetailModelPL newModel, int accessPointId = 0)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            var id = await safetyFunctionFacade.CreateAsync(newModel, userId, accessPointId);
            return Ok(id);
        }

        // POST: api/safetyFunction/sil
        [HttpPost("sil")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "SafetyFunctionCreateSIL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateAsync(SafetyFunctionDetailModelSIL newModel, int accessPointId = 0)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            var id = await safetyFunctionFacade.CreateAsync(newModel, userId, accessPointId);
            return Ok(id);
        }

        // PUT: api/safetyFunction/pl
        [HttpPut("pl")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "SafetyFunctionUpdatePL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> UpdateAsync(SafetyFunctionDetailModelPL updatedModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            var id = await safetyFunctionFacade.UpdateAsync(updatedModel, userId);
            return Ok(id);
        }

        // PUT: api/safetyFunction/sil
        [HttpPut("sil")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "SafetyFunctionUpdateSIL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> UpdateAsync(SafetyFunctionDetailModelSIL updatedModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            var id = await safetyFunctionFacade.UpdateAsync(updatedModel, userId);
            return Ok(id);
        }

        // DELETE: api/safetyFunction/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "SafetyFunctionDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id == 0)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            await safetyFunctionFacade.DeleteAsync(id, userId);
            return Ok();
        }

        // POST: api/safetyFunction/addSubsystem/{safetyFunctionId}/{subsystemId}
        [HttpPost("addSubsystem/{safetyFunctionId}/{subsystemId}")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "SafetyFunctionAddSubsystem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddSubsystemAsync(int safetyFunctionId, int subsystemId)
        {
            if (safetyFunctionId == 0 || subsystemId == 0)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            await safetyFunctionFacade.AddSubsystemAsync(safetyFunctionId, subsystemId, userId);
            return Ok();
        }

        // DELETE: api/safetyFunction/removeSubsystem/{safetyFunctionId}/{subsystemId}
        [HttpDelete("removeSubsystem/{safetyFunctionId}/{subsystemId}")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "SafetyFunctionRemoveSubsystem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RemoveSubsystemAsync(int safetyFunctionId, int subsystemId)
        {
            if (safetyFunctionId == 0 || subsystemId == 0)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            await safetyFunctionFacade.RemoveSubsystemAsync(safetyFunctionId, subsystemId, userId);
            return Ok();
        }

        // GET: api/safetyFunction/pl/evaluateSafetyFunction/{id}
        [HttpGet("pl/evaluateSafetyFunction/{id}")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "SafetyFunctionEvaluatePL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SafetyEvaluationResponseModel>> EvaluateSafetyFunctionPLAsync(int id)
        {
            if (id == 0)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            var response = await safetyFunctionFacade.EvaluateSafetyFunctionPLAsync(id, userId);
            return Ok(response);
        }

        // GET: api/safetyFunction/sil/evaluateSafetyFunction/{id}
        [HttpGet("sil/evaluateSafetyFunction/{id}")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "SafetyFunctionEvaluateSIL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SafetyEvaluationResponseModel>> EvaluateSafetyFunctionSILAsync(int id)
        {
            if (id == 0)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            var response = await safetyFunctionFacade.EvaluateSafetyFunctionSILAsync(id, userId);
            return Ok(response);
        }
    }
}
