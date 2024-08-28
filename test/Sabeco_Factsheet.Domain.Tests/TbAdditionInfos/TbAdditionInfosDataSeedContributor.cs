using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbAdditionInfos;

namespace Sabeco_Factsheet.TbAdditionInfos
{
    public class TbAdditionInfosDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbAdditionInfoRepository _tbAdditionInfoRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbAdditionInfosDataSeedContributor(ITbAdditionInfoRepository tbAdditionInfoRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbAdditionInfoRepository = tbAdditionInfoRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbAdditionInfoRepository.InsertAsync(new TbAdditionInfo
            (
                companyId: 1000767793,
                docDate: new DateTime(2023, 2, 23),
                typeOfGroup: "89fc27c731924ba186d93c69c84537b65c72f830a4ca465aab",
                typeOfEvent: "3a02d9",
                description: "c45ae0b3e92d4fa0b14bdbdf51e5a832442d62d623f043e5a7cecd44bc6dfcb4eefcba5f95ee416cac4e64",
                noOfDocument: "bfbcbb766d114b94ad7466c36ddc8c29effeafb242f04448a195956f61cd6de3644dc0a",
                remark: "69b73435443f49e7b1630622f05f434d8ada",
                isActive: true
            ));

            await _tbAdditionInfoRepository.InsertAsync(new TbAdditionInfo
            (
                companyId: 683937195,
                docDate: new DateTime(2008, 7, 6),
                typeOfGroup: "c35def450dda453497414fe3344aea450f14462b330d4946bd",
                typeOfEvent: "5fe496e7e98b45c3910e83fdf0ba5d8502e5341c9f684e01",
                description: "5a9f093a51fe46f18b27d9556ae44bca526c1b7caf134cab9be8d0493938",
                noOfDocument: "579a8303d87b412497e1da9619bc7789173eed10da0c49ccad4a1efdc6f4c62d9",
                remark: "3cab9ef8566940059bfc",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}