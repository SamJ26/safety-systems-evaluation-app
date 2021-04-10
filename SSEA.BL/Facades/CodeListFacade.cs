using AutoMapper;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.Common;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.PL;
using SSEA.BL.Models.SafetyEvaluation.CodeListModels.SIL;
using SSEA.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSEA.BL.Facades
{
    public class CodeListFacade
    {
        private readonly IMapper mapper;
        private readonly CodeListRepository codeListRepository;

        public CodeListFacade(IMapper mapper, CodeListRepository codeListRepository)
        {
            this.mapper = mapper;
            this.codeListRepository = codeListRepository;
        }

        public async Task<dynamic> GetAllAsync(string typeName)
        {
            return typeName.ToLower() switch
            {
                "dc" => mapper.Map<ICollection<DCModel>>(await codeListRepository.GetAllDCsAsync()),

                "ccf" => mapper.Map< ICollection<CCFModel>>(await codeListRepository.GetAllCCFsAsync()),

                "evaluationmethod" => mapper.Map< ICollection<EvaluationMethodModel>>(await codeListRepository.GetAllEvaluationMethodsAsync()),

                "machinetype" => mapper.Map<ICollection<MachineTypeModel>>(await codeListRepository.GetAllMachineTypesAsync()),

                "norm" => mapper.Map<ICollection<NormModel>>(await codeListRepository.GetAllNormsAsync()),

                "typeoffunction" => mapper.Map<ICollection<TypeOfFunctionModel>>(await codeListRepository.GetAllTypeOfFunctionsAsync()),

                "typeoflogic" => mapper.Map<ICollection<TypeOfLogicModel>>(await codeListRepository.GetAllTypeOfLogicsAsync()),

                "typeofsubsystem" => mapper.Map<ICollection<TypeOfSubsystemModel>>(await codeListRepository.GetAllTypeOfSubsystemsAsync()),

                "category" => mapper.Map<ICollection<CategoryModel>>(await codeListRepository.GetAllCategorysAsync()),

                "f" => mapper.Map<ICollection<FModel>>(await codeListRepository.GetAllFsAsync()),

                "mttfd" => mapper.Map<ICollection<MTTFdModel>>(await codeListRepository.GetAllMTTFdsAsync()),

                "pl" => mapper.Map<ICollection<PLModel>>(await codeListRepository.GetAllPLsAsync()),

                "p" => mapper.Map<ICollection<PModel>>(await codeListRepository.GetAllPsAsync()),

                "s" => mapper.Map<ICollection<SModel>>(await codeListRepository.GetAllSsAsync()),

                "architecture" => mapper.Map<ICollection<ArchitectureModel>>(await codeListRepository.GetAllArchitecturesAsync()),

                "av" => mapper.Map<ICollection<AvModel>>(await codeListRepository.GetAllAvsAsync()),

                "fr" => mapper.Map<ICollection<FrModel>>(await codeListRepository.GetAllFrsAsync()),

                "pfhd" => mapper.Map<ICollection<PFHdModel>>(await codeListRepository.GetAllPFHdsAsync()),

                "pr" => mapper.Map<ICollection<PrModel>>(await codeListRepository.GetAllPrsAsync()),

                "se" => mapper.Map<ICollection<SeModel>>(await codeListRepository.GetAllSesAsync()),

                "sff" => mapper.Map<ICollection<SFFModel>>(await codeListRepository.GetAllSFFsAsync()),

                "producer" => mapper.Map<ICollection<ProducerModel>>(await codeListRepository.GetAllProducersAsync()),

                "operationprinciple" => mapper.Map<ICollection<OperationPrincipleModel>>(await codeListRepository.GetAllOperationPrinciplesAsync()),

                _ => null,
            };
        }
    }
}
