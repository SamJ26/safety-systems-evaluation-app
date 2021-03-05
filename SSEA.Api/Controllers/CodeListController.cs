using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using SSEA.BL.Facades;
using System.Net.Http;
using System.Text.Json;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels;

namespace SSEA.Api.Controllers
{
    [Route("api/codeList")]
    [ApiController]
    public class CodeListController : ControllerBase
    {
        private readonly CodeListFacade codeListFacade;

        public CodeListController(CodeListFacade codeListFacade)
        {
            this.codeListFacade = codeListFacade;
        }

        /// <summary>
        /// Route: api/codeList/{typeName} <br/>
        /// This controller method returns all records from database for selected type of entity <br/>
        /// E.g. api/codelist/typeOfFunction - controller returns all types of function from database (all records from table TypeOfFunction) <br/>
        /// </summary>
        /// <param name="typeName"> Name of entity (type) </param>
        /// <returns> All records as JSON string </returns>
        [HttpGet("{typeName}")]
        [SwaggerOperation(OperationId = "CodeListGetAll")]
        public async Task<ActionResult<CodeListResponseModel>> GetAll(string typeName)
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

        /// <summary>
        /// Route: api/codeList/{typeName} <br/>
        /// This controller method creates new record in specific table in database <br/>
        /// Table is specified by typeName parameter <br/>
        /// </summary>
        /// <param name="typeName"> Name of entity (type) </param>
        /// <param name="jsonObject"> Serialized object of type typeName </param>
        /// <returns> Id of created record </returns>
        [HttpPost("{typeName}")]
        [SwaggerOperation(OperationId = "CodeListCreate")]
        public ActionResult<int> Create(string typeName, [FromBody] JObject jsonObject)
        {
            return Ok();
        }

        /// <summary>
        /// Route: api/codeList <br/>
        /// This controller updates record in specific table in database <br/>
        /// Table is specified by typeName parameter <br/>
        /// </summary>
        /// <param name="typeName"> Name of entity (type) </param>
        /// <param name="jsonObject"> Serialized object of type typeName </param>
        /// <returns> Id of updated record </returns>
        [HttpPut("{typeName}")]
        [SwaggerOperation(OperationId = "CodeListUpdate")]
        public ActionResult<int> Update(string typeName, [FromBody] JObject jsonObject)
        {
            return Ok();
        }

        /// <summary>
        /// Route: api/codeList/{typeName}/{id} <br/>
        /// This controller deletes record from specific table in database <br/>
        /// Table is specified by typeName parameter <br/>
        /// Deleted record is not permanently removed, but just mark as removed (using soft-delete) <br/>
        /// </summary>
        /// <param name="typeName"> Name of entity (type) </param>
        /// <param name="id"> Id of deleted record </param>
        /// <returns></returns>
        [HttpDelete("{typeName}/{id}")]
        [SwaggerOperation(OperationId = "CodeListDelete")]
        public ActionResult Delete(string typeName, int id)
        {
            return Ok();
        }
    }
}
