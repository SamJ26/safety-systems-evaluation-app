using Microsoft.AspNetCore.Authorization;
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

        // Route: api/machine
        [HttpGet]
        [SwaggerOperation(OperationId = "MachineGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<MachineListModel>>> GetAll()
        {
            var data = await machineFacade.GetAllAsync();
            return Ok(data);
        }

        // Route: api/machine/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(OperationId = "MachineGetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MachineDetailModel>> GetById(int id)
        {
            var data = await machineFacade.GetByIdAsync(id);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        // Route: api/machine
        [HttpPost]
        [SwaggerOperation(OperationId = "MachineCreate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create(MachineDetailModel newModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var id = await machineFacade.CreateAsync(newModel);
            return Ok(id);
        }

        // Route: api/machine
        [HttpPut]
        [SwaggerOperation(OperationId = "MachineUpdate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Update(MachineDetailModel updatedModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var id = await machineFacade.UpdateAsync(updatedModel);
            return Ok(id);
        }

        // Route: api/machine/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(OperationId = "MachineDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var foundId = await machineFacade.DeleteAsync(id);
            if (foundId == 0)
                return BadRequest();
            return Ok();
        }
    }
}
