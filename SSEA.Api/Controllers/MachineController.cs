using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSEA.BL.Facades;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using Swashbuckle.AspNetCore.Annotations;
using SSEA.Api.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEA.Api.Controllers
{
    [Authorize]
    [Route("api/machine")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly MachineFacade machineFacade;

        public MachineController(MachineFacade machineFacade)
        {
            this.machineFacade = machineFacade;
        }

        // GET: api/machine
        [HttpGet]
        [SwaggerOperation(OperationId = "MachineGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<MachineListModel>>> GetAllAsync([FromQuery] string machineName,
                                                                                   [FromQuery] int stateId = 0,
                                                                                   [FromQuery] int machineTypeId = 0,
                                                                                   [FromQuery] int evaluationMethodId = 0,
                                                                                   [FromQuery] int producerId = 0)
        {
            var data = await machineFacade.GetAllAsync(machineName, stateId, machineTypeId, evaluationMethodId, producerId);
            return Ok(data);
        }

        // GET: api/machine/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(OperationId = "MachineGetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MachineDetailModel>> GetByIdAsync(int id)
        {
            var data = await machineFacade.GetByIdAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        // POST: api/machine
        [HttpPost]
        //[Authorize(Roles = "Administrator")]
        //[Authorize(Roles = "NormalUser")]
        [SwaggerOperation(OperationId = "MachineCreate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateAsync(MachineDetailModel newModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            var id = await machineFacade.CreateAsync(newModel, userId);
            return Ok(id);
        }

        // PUT: api/machine
        [HttpPut]
        //[Authorize(Roles = "Administrator")]
        //[Authorize(Roles = "NormalUser")]
        [SwaggerOperation(OperationId = "MachineUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> UpdateAsync(MachineDetailModel updatedModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            var id = await machineFacade.UpdateAsync(updatedModel, userId);
            return Ok(id);
        }

        //// DELETE: api/machine/{id}
        //[HttpDelete("{id}")]
        ////[Authorize(Roles = "Administrator")]
        ////[Authorize(Roles = "NormalUser")]
        //[SwaggerOperation(OperationId = "MachineDelete")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> DeleteAsync(int id)
        //{
        //    var userId = this.GetUserIdFromHttpContext();
        //    var foundId = await machineFacade.DeleteAsync(id, userId);
        //    if (foundId == 0)
        //        return BadRequest();
        //    return Ok();
        //}
    }
}
