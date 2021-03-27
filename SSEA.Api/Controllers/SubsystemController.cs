using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSEA.Api.Extensions;
using SSEA.BL.Facades;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
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

        //// GET: api/subsystem/pl/{id}
        //[HttpGet("pl/{id}")]
        //[SwaggerOperation(OperationId = "SubsystemGetAllPL")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<ICollection<SubsystemDetailModelPL>>> GetAllPLAsync(int safetyFunctionId = 0)
        //{
        //    ICollection<SubsystemDetailModelPL> data;
        //    if (safetyFunctionId == 0)
        //        data = await subsystemFacade.GetAllPLAsync();
        //    else
        //        data = await subsystemFacade.GetAllPLAsync(safetyFunctionId);
        //    return Ok(data);
        //}

        //// GET: api/subsystem/sil/{id}
        //[HttpGet("sil/{id}")]
        //[SwaggerOperation(OperationId = "SubsystemGetAllSIL")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<ICollection<SubsystemDetailModelSIL>>> GetAllSILAsync(int safetyFunctionId = 0)
        //{
        //    ICollection<SubsystemDetailModelSIL> data;
        //    if (safetyFunctionId == 0)
        //        data = await subsystemFacade.GetAllSILAsync();
        //    else
        //        data = await subsystemFacade.GetAllSILAsync(safetyFunctionId);
        //    return Ok(data);
        //}

        //// GET: api/subsystem/detail/pl/{id}
        //[HttpGet("detail/pl/{id}")]
        //[SwaggerOperation(OperationId = "SubsystemGetByIdPL")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<SubsystemDetailModelPL>> GetByIdPLAsync(int id)
        //{
        //    var data = await subsystemFacade.GetByIdPLAsync(id);
        //    if (data == null)
        //        return NotFound();
        //    return Ok(data);
        //}

        //// GET: api/subsystem/detail/sil/{id}
        //[HttpGet("detail/sil/{id}")]
        //[SwaggerOperation(OperationId = "SubsystemGetByIdSIL")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<SubsystemDetailModelSIL>> GetByIdSILAsync(int id)
        //{
        //    var data = await subsystemFacade.GetByIdSILAsync(id);
        //    if (data == null)
        //        return NotFound();
        //    return Ok(data);
        //}

        //// POST: api/subsystem/pl
        //[HttpPost("pl")]
        //[SwaggerOperation(OperationId = "SubsystemCreatePL")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<int>> CreateAsync(SubsystemDetailModelPL model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();
        //    var userId = this.GetUserIdFromHttpContext();
        //    var id = await subsystemFacade.CreateAsync(model, userId);
        //    return Ok(id);
        //}

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
