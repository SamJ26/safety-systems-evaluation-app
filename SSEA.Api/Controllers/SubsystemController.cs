using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSEA.BL.Facades;
using SSEA.BL.Models.SafetyEvaluation.MainModels.DetailModels;
using SSEA.BL.Models.SafetyEvaluation.MainModels.ListModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSEA.Api.Controllers
{
    [Route("api/subsystem")]
    [ApiController]
    public class SubsystemController : ControllerBase
    {
        private readonly SubsystemFacade subsystemFacade;

        public SubsystemController(SubsystemFacade subsystemFacade)
        {
            this.subsystemFacade = subsystemFacade;
        }

        // api/subsystem
        [HttpGet]
        public ActionResult<IEnumerable<SubsystemListModel>> GetAll()
        {
            return Ok();
        }

        // api/subsystem/pl/{id}
        [HttpGet("pl/{id}")]
        public ActionResult<SubsystemDetailModelPL> GetByIdPL(int id)
        {
            return Ok();
        }

        // api/subsystem/sil/{id}
        [HttpGet("sil/{id}")]
        public ActionResult<SubsystemDetailModelSIL> GetByIdSIL(int id)
        {
            return Ok();
        }

        // api/subsystem/pl
        [HttpPost("pl")]
        public ActionResult<int> Create(SubsystemDetailModelPL newModel)
        {
            return Ok();
        }

        // api/subsystem/sil
        [HttpPost("sil")]
        public ActionResult<int> Create(SubsystemDetailModelSIL newModel)
        {
            return Ok();
        }

        // api/subsystem/pl
        [HttpPut("pl")]
        public ActionResult<int> Update(SubsystemDetailModelPL updatedModel)
        {
            return Ok();
        }

        // api/subsystem/sil
        [HttpPut("sil")]
        public ActionResult<int> Update(SubsystemDetailModelSIL updatedModel)
        {
            return Ok();
        }

        // api/subsystem/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
