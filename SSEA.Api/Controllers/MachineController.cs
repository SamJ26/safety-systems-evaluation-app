﻿using Microsoft.AspNetCore.Http;
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
        public ActionResult<MachineDetailModel> GetById(int id)
        {
            return Ok();
        }

        // Route: api/machine
        [HttpPost]
        [SwaggerOperation(OperationId = "MachineCreate")]
        public ActionResult<int> Create(MachineDetailModel newModel)
        {
            return Ok();
        }

        // Route: api/machine
        [HttpPut]
        [SwaggerOperation(OperationId = "MachineUpdate")]
        public ActionResult<int> Update(MachineDetailModel updatedModel)
        {
            return Ok();
        }

        // Route: api/machine/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(OperationId = "MachineDelete")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
