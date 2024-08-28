using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbConfigRetirementTimes;

namespace Sabeco_Factsheet.TbConfigRetirementTimes
{
    public class TbConfigRetirementTimesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbConfigRetirementTimeRepository _tbConfigRetirementTimeRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbConfigRetirementTimesDataSeedContributor(ITbConfigRetirementTimeRepository tbConfigRetirementTimeRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbConfigRetirementTimeRepository = tbConfigRetirementTimeRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbConfigRetirementTimeRepository.InsertAsync(new TbConfigRetirementTime
            (
                code: "ece4be9c97c64be6a4e621fae6124b8edd3ad8e40cad4ae3b0f35aa82b2384238af83601f7ca4ef0aabc9089c98de9",
                yearNumb: 1780874477,
                monthNumb: 1359084931,
                dayNumb: 351067645,
                note: "9a89616d566a4ae699583f3dff873283976b4752423b40ecb852c446f7ab29094136e09419734fc09a7a149e881397"
            ));

            await _tbConfigRetirementTimeRepository.InsertAsync(new TbConfigRetirementTime
            (
                code: "1e84d7",
                yearNumb: 903667439,
                monthNumb: 67963502,
                dayNumb: 1331519045,
                note: "c9e3ffff39f34c21864f6d2050054b8d3d1a05dcd"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}