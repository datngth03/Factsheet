using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbBreweryTemps;

namespace Sabeco_Factsheet.TbBreweryTemps
{
    public class TbBreweryTempsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbBreweryTempRepository _tbBreweryTempRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbBreweryTempsDataSeedContributor(ITbBreweryTempRepository tbBreweryTempRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbBreweryTempRepository = tbBreweryTempRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbBreweryTempRepository.InsertAsync(new TbBreweryTemp
            (
                idBrewery: 414628083,
                breweryCode: "042e3569feee4791bebb",
                breweryName: "2548896acc714bdca75c210dcccd538be88c4884f61a48aab8d6530a8c80531dd87f238dafae4606981ffec16fdc891d9ce153f7307e48199dbe6bd0c6fbf8c8a22381957bbf41d5abf45e3091cc340b47a8bc2484d14488b7c2fb78c5138218deb57bd072bc414bae8736445835690de10bae4957dd41f797cae9582a",
                breweryName_EN: "cbcf394b5e084217a62326f8a029f7cc01d8126eb39c40549c9c905aa3cb4c51bb5babca8617465794829b8f31fb0174838f7a1eb7d940248fbd4796d41e6c6966ffd7d3132846fa900251cd253379cda0960ce69d644fba957baf3f3d75d681955e361835ad4c95a46307981d075f7fd133dfbbe1ea4a4abcf28fa143",
                briefName: "2729ecde9bcb4cf7b1b087f6b5eb08a3f912a30ac87649e9b9862317dd6540d7d",
                breweryAdress: "49b94b74ded0499eb0f49a91a5f7eae991b62f3b37014eb48dbdb4053215ed02",
                companyId: 1566405599,
                capacityVolume: 615501144,
                deliveryVolume: 8724822,
                note: "da7eeff18bce47699798e59afb2",
                docStatus: 64,
                isActive: true
            ));

            await _tbBreweryTempRepository.InsertAsync(new TbBreweryTemp
            (
                idBrewery: 141653400,
                breweryCode: "eae425ae03944794a3e5",
                breweryName: "55a96efbdc0545a0b2beae266445235d874d5d4a0b46422e9037a3a5233975a5c7ba3742f01a4ebbbcf4c4e6f7f16344f314a0dc73414b97ac149ca51126dce1473ed8761c524f86a606ed53d0a5d043423fc7b42eeb49fea438706bcaf1b0a2084127ffc9484fc49a44649425f2f1426ce8194da2464811b36712e770",
                breweryName_EN: "60edca0dc64f4213afee31ad0ac68d35581b403a997a44ff8eb25eb7703a26b7e375f2ea22af4aba888e6756422c0e1ca6c5b4e692b042c5981694af72eca5d54af8e8c9b3cf44d6b833c16ce458871bacc5450cb083432bb6cf449428531650e3ae83f48d5b487c9826290a13c27ccd364e9a8eec4743308d399c4777",
                briefName: "d0fb9d66eb264be",
                breweryAdress: "8d2e5df809434bfeb8c4537b03c19f31b23ee83630dd4a8f80cf5f75bc4d6e5067ebdfa3b23741fbb",
                companyId: 2089941437,
                capacityVolume: 191880497,
                deliveryVolume: 1264481112,
                note: "0e6e53e9c2cb4672b8f5b9e669e47b842274fe4f561b47f88c881",
                docStatus: 20,
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}