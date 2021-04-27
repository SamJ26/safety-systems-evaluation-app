using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSEA.Api.Extensions;
using SSEA.BL.Facades;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEA.Api.Controllers
{
    [Authorize]
    [Route("api/accessPoint")]
    [ApiController]
    public class AccessPointController : ControllerBase
    {
        private readonly AccessPointFacade accessPointFacade;

        public AccessPointController(AccessPointFacade accessPointFacade)
        {
            this.accessPointFacade = accessPointFacade;
        }

        // GET: api/accessPoint
        [HttpGet]
        [SwaggerOperation(OperationId = "AccessPointGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ICollection<AccessPointListModel>>> GetAllAsync()
        {
            var data = await accessPointFacade.GetAllAsync();
            if (data is null)
                return NotFound();
            return Ok(data);
        }

        // GET: api/accessPoint/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(OperationId = "AccessPointGetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccessPointDetailModel>> GetByIdAsync(int id)
        {
            if (id == 0)
                return BadRequest();
            var data = await accessPointFacade.GetByIdAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        // PUT: api/accessPoint
        [HttpPut]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "AccessPointUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> UpdateAsync(AccessPointDetailModel updatedModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            int id;
            try
            {
                id = await accessPointFacade.UpdateAsync(updatedModel, userId);
            }
            catch (System.UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            if (id == 0)
                return StatusCode(500);
            return Ok(id);
        }

        // DELETE: api/accessPoint/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "AccessPointDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (id == 0)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            try
            {
                await accessPointFacade.DeleteAsync(id, userId);
            }
            catch (System.UnauthorizedAccessException)
            {
                return Unauthorized();
            }            
            return Ok();
        }

        // POST: api/accessPoint/addSafetyFunction/{accessPointId}/{safetyFunctionId}
        [HttpPost("addSafetyFunction/{accessPointId}/{safetyFunctionId}")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "AccessPointAddSafetyFunction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> AddSafetyFunctionAsync(int accessPointId, int safetyFunctionId)
        {
            if (safetyFunctionId == 0 || accessPointId == 0)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            try
            {
                await accessPointFacade.AddSafetyFunctionAsync(accessPointId, safetyFunctionId, userId);
            }
            catch (System.UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            return Ok();
        }

        // DELETE: api/accessPoint/removeSafetyFunction/{accessPointId}/{safetyFunctionId}
        [HttpDelete("removeSafetyFunction/{accessPointId}/{safetyFunctionId}")]
        [Authorize(Roles = "SafetyEvaluationAdmin, NormalUser")]
        [SwaggerOperation(OperationId = "AccessPointRemoveSafetyFunction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> RemoveSafetyFunctionAsync(int accessPointId, int safetyFunctionId)
        {
            if (safetyFunctionId == 0 || accessPointId == 0)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            try
            {
                await accessPointFacade.RemoveSafetyFunctionAsync(accessPointId, safetyFunctionId, userId);
            }
            catch (System.UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            return Ok();
        }
    }
}
