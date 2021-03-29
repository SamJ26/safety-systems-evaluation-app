using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSEA.Api.Extensions;
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
        [SwaggerOperation(OperationId = "SafetyFunctionCreatePL")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateAsync(SafetyFunctionDetailModelPL newModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userId = this.GetUserIdFromHttpContext();
            var id = await safetyFunctionFacade.CreateAsync(newModel, userId);
            return Ok(id);
        }

        //// POST: api/safetyFunction/sil
        //[HttpPost("sil")]
        //[SwaggerOperation(OperationId = "SafetyFunctionCreateSIL")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<int>> CreateAsync(SafetyFunctionDetailModelSIL newModel)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();
        //    var userId = this.GetUserIdFromHttpContext();
        //    var id = await safetyFunctionFacade.CreateAsync(newModel, userId);
        //    return Ok(id);
        //}
    }
}
