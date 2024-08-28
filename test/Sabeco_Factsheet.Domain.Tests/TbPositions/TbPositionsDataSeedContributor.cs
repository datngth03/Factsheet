using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbPositions;

namespace Sabeco_Factsheet.TbPositions
{
    public class TbPositionsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbPositionRepository _tbPositionRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbPositionsDataSeedContributor(ITbPositionRepository tbPositionRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbPositionRepository = tbPositionRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbPositionRepository.InsertAsync(new TbPosition
            (
                code: "9c745311b3bb42f3b38f",
                name: "c5d5dba963b349c28ebe531351012c66d8e972dc3f0641cca50e3beacbda46baae3d27ffcdde4e6ca4f2e42eab0447f9c85b331794784c96b791b132aed4bd45f35db65f49af41009c34f1ab94309997e1fa67ad2e3248f6a60a15ac5074a3628a98f7791d784cd7ab2798c0d3d7ef4f1611bcf8135049dcbc4cc4d49e",
                name_EN: "32eda28918e24dcd9a50ceb98d08fcc2f99c7280cb20419ab2765cf2086b222f5213cd1134a54699860654a30549c5c0304e6776c72f4f188e7e9a55cca40325ebfeed2219b242ad817f52a49630329a1033f9d6991f40fab3114cf9611b31b2fa107e189c2e4ad48ed0b37d44b69acbad242f31349c4d64895e1a4b14",
                positionType: 63,
                isActive: true,
                orderNumb: 414843421
            ));

            await _tbPositionRepository.InsertAsync(new TbPosition
            (
                code: "fad05956c77049f9a15c",
                name: "69659d691f224f52ac5acfa3484717e2c3c4ff79a65a4504a6916965341777265b7228c07f41491f80ccc151cc72b67060845b9f07554ee299b4db0967e880c16e2bbd3658be41f3b1ef12a59b7871d1b6903ed32b714091b5f3c2e5c6590c3449d1370882f14f5d8ec6f4b147d82021ddb3a4b400d846ebbd13b9b8f4",
                name_EN: "02ecda4ac7414583a4f46067ce0c6d81ecd906dcc2f64f5985931ee21e3681c1c8b0caaa2bec466ba8cd09c994e64f9d8980142fea534d00a104ec14f16c2c9c4dd807003716445781db65429f590fef1a97fd77ae8242729599db30bf436563912943d4152e400c99f35119f7f51de20bf54176657041d49b32f6514d",
                positionType: 1,
                isActive: true,
                orderNumb: 1441633880
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}