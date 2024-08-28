using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbLandInfos;

namespace Sabeco_Factsheet.TbLandInfos
{
    public class TbLandInfosDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbLandInfoRepository _tbLandInfoRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbLandInfosDataSeedContributor(ITbLandInfoRepository tbLandInfoRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbLandInfoRepository = tbLandInfoRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbLandInfoRepository.InsertAsync(new TbLandInfo
            (
                companyId: 1843628872,
                description: "58bc7277b09d4504bbd90cc37b531",
                address: "b6b92bfb88954643a68",
                typeOfLand: "567b0268cb9d4712b60827faf320f9",
                area: 613272803,
                supportingDocument: "7a92138637d34bf0bdf83089eb9dfc66499123c973334b45a57131fee9b6def24f810d1ff25743a0b54e14",
                issueDate: new DateTime(2018, 10, 16),
                expiryDate: new DateTime(2011, 1, 24),
                payment: "a5d147ed6cc944899b6a16b0499dc1a838d03e9dca774da99ad810c1fe7682319ed0df6b93d94",
                remark: "cd2347b7ee81415ca03dbc8a441a28",
                isActive: true
            ));

            await _tbLandInfoRepository.InsertAsync(new TbLandInfo
            (
                companyId: 460667226,
                description: "f05196ef55704f6f84348d435df9515a6c78a382f703406782628228bb1",
                address: "a67ec151c1d943fe9738063d838e7b2b55dad887360c455ea76bbb4b2",
                typeOfLand: "1627b0550011453984347",
                area: 2035005091,
                supportingDocument: "3c5a06d1a3b64305bb3e3bd519ac8833ae0a0302f35a4369b6ec941170818e62463a0c4681",
                issueDate: new DateTime(2002, 5, 15),
                expiryDate: new DateTime(2006, 7, 8),
                payment: "a5fd7712753c4ac985a8ed6e39288dfc2636d00739014c0c9b6",
                remark: "f653651ef5994023a5985ee1d588574c",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}