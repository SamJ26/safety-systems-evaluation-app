using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.Api.Controllers
{
    [Route("api/codeList")]
    [ApiController]
    public class CodeListController : ControllerBase
    {
        public CodeListController()
        {

        }

        /// <summary>
        /// Route: api/codeList/{typeName} <br/>
        /// This controller method returns all records from database for selected type of entity <br/>
        /// E.g. api/codelist/typeOfFunction - controller returns all types of function from database (all records from table TypeOfFunction) <br/>
        /// </summary>
        /// <param name="typeName"> Name of entity (type) </param>
        /// <returns> All records as JSON </returns>
        [HttpGet("{typeName}")]
        public ActionResult<IEnumerable<JObject>> GetAll(string typeName)
        {
            return Ok();
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
        public ActionResult Delete(string typeName, int id)
        {
            return Ok();
        }
    }
}
