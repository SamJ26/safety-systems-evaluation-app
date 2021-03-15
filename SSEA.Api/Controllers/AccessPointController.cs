using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/accessPoint")]
    [ApiController]
    public class AccessPointController : ControllerBase
    {
        private readonly AccessPointFacade accessPointFacade;

        public AccessPointController(AccessPointFacade accessPointFacade)
        {
            this.accessPointFacade = accessPointFacade;
        }

        // Route: api/accessPoint
        [HttpGet]
        [SwaggerOperation(OperationId = "AccessPointGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<AccessPointListModel>>> GetAll()
        {
            var data = await accessPointFacade.GetAllAsync();
            return Ok(data);
        }

        // Route: api/accessPoint/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(OperationId = "AccessPointGetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccessPointDetailModel>> GetById(int id)
        {
            var data = await accessPointFacade.GetByIdAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        // Route: api/accessPoint
        [HttpPost]
        [SwaggerOperation(OperationId = "AccessPointCreate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create(AccessPointDetailModel newModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var id = await accessPointFacade.CreateAsync(newModel);
            return Ok(id);
        }

        // Route: api/accessPoint
        [HttpPut]
        [SwaggerOperation(OperationId = "AccessPointUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Update(AccessPointDetailModel updatedModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            // var id = await accessPointFacade.UpdateAsync(updatedModel);
            return Ok(1);
        }

        // Route: api/accessPoint/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(OperationId = "AccessPointDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id, bool softDelete = true)
        {
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
