using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSEA.Api.Extensions;
using SSEA.BL.Facades;
using SSEA.BL.Models.SafetyEvaluation.JoinModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult<ICollection<AccessPointListModel>>> GetAllAsync()
        {
            var data = await accessPointFacade.GetAllAsync();
            return Ok(data);
        }

        // GET: api/accessPoint/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(OperationId = "AccessPointGetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccessPointDetailModel>> GetByIdAsync(int id)
        {
            var data = await accessPointFacade.GetByIdAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        // POST: api/accessPoint
        [HttpPost]
        [SwaggerOperation(OperationId = "AccessPointCreate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateAsync(AccessPointDetailModel newModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            var id = await accessPointFacade.CreateAsync(newModel, userId);
            return Ok(id);
        }

        // PUT: api/accessPoint
        [HttpPut]
        [SwaggerOperation(OperationId = "AccessPointUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> UpdateAsync(AccessPointDetailModel updatedModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            // var id = await accessPointFacade.UpdateAsync(updatedModel, userId);
            return Ok(1);
        }

        // DELETE: api/accessPoint/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(OperationId = "AccessPointDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteAsync(int id, bool softDelete = true)
        {
            var userId = this.GetUserIdFromHttpContext();
            var foundId = await accessPointFacade.DeleteAsync(id, softDelete);
            if (foundId == 0)
                return BadRequest();
            return Ok();
        }

        // POST: api/accessPoint/addSafetyFunction
        [HttpPost("addSafetyFunction")]
        [SwaggerOperation(OperationId = "AccessPointAddSafetyFunctionAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddSafetyFunctionAsync(AccessPointSafetyFunctionModel model)
        {
            if (model.AccessPointId == 0 || model.SafetyFunctionId == 0)
                return BadRequest();
            var result = await accessPointFacade.AddSafetyFunctionAsync(model);
            return Ok(result);
        }
    }
}
