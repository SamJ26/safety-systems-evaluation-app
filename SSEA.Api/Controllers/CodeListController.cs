using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using SSEA.BL.Facades;
using System.Text.Json;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels;
using Microsoft.AspNetCore.Authorization;

namespace SSEA.Api.Controllers
{
    [Authorize]
    [Route("api/codeList")]
    [ApiController]
    public class CodeListController : ControllerBase
    {
        private readonly CodeListFacade codeListFacade;

        public CodeListController(CodeListFacade codeListFacade)
        {
            this.codeListFacade = codeListFacade;
        }

        // GET: api/codeList/{typeName}
        [HttpGet("{typeName}")]
        [SwaggerOperation(OperationId = "CodeListGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CodeListResponseModel>> GetAllAsync(string typeName)
        {
            dynamic data = await codeListFacade.GetAllAsync(typeName);
            if (data == null)
                return NotFound(new CodeListResponseModel());
            string json = JsonSerializer.Serialize(data);
            CodeListResponseModel response = new()
            {
                Data = json,
                Count = (uint)data.Count,
            };       
            return Ok(response);
        }
    }
}
