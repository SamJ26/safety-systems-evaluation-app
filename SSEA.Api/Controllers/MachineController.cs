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
    [Route("api/machine")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly MachineFacade machineFacade;

        public MachineController(MachineFacade machineFacade)
        {
            this.machineFacade = machineFacade;
        }

        // api/machine
        [HttpGet]
        public ActionResult<IEnumerable<MachineListModel>> GetAll()
        {
            return Ok();
        }

        // api/machine/{id}
        [HttpGet("{id}")]
        public ActionResult<MachineDetailModel> GetById(int id)
        {
            return Ok();
        }

        // api/machine
        [HttpPost]
        public ActionResult<int> Create(MachineDetailModel newModel)
        {
            return Ok();
        }

        // api/machine
        [HttpPut]
        public ActionResult<int> Update(MachineDetailModel updatedModel)
        {
            return Ok();
        }

        // api/machine/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
