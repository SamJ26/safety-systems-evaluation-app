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
        /// This controller returns all records from database for selected type of entity <br/>
        /// E.g. api/codelist/typeOfFunction - controller returns all types of function from database (all records from table TypeOfFunction) <br/>
        /// </summary>
        /// <param name="typeName"> Name of entity (type) </param>
        /// <returns> All records as JSON </returns>
        [HttpGet("{typeName}")]
        public ActionResult<JObject> GetAll(string typeName)
        {
            return Ok();
        }

        [HttpGet("{typeName}")]
        public ActionResult<int> Create(JObject jsonObject)
        {
            return Ok();
        }

        // TODO: add all endpoints
    }
}
