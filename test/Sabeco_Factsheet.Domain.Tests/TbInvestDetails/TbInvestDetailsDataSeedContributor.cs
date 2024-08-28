using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbInvestDetails;

namespace Sabeco_Factsheet.TbInvestDetails
{
    public class TbInvestDetailsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbInvestDetailRepository _tbInvestDetailRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbInvestDetailsDataSeedContributor(ITbInvestDetailRepository tbInvestDetailRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbInvestDetailRepository = tbInvestDetailRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbInvestDetailRepository.InsertAsync(new TbInvestDetail
            (
                parentId: 1766792569,
                docDate: new DateTime(2006, 2, 8),
                docNo: "b7a6ff7fe4f04c6c952be9b8c6381b158534c2ae57d24ccc90",
                investType: 1744631051,
                shareNum: 1484569157,
                shareValue: 2131756308,
                note: "f2d2e60447134ad4991a037c4c7a76ee97f7f0e62c0043daa8394985523efcccb62461474bfb461fa2d5731b77c178dfabbe1a3f38e84b4594058fe10d8ac9a2ad22fc87ca804516af7ae698e63c0949c2cd670a6a854b31a058fca837d78af8ac350c3702de4c1594c6efc45f54b432db8161d970824e268314f453d3",
                isActive: true
            ));

            await _tbInvestDetailRepository.InsertAsync(new TbInvestDetail
            (
                parentId: 578589055,
                docDate: new DateTime(2001, 8, 20),
                docNo: "edf2d1bd27ce4cecb1d61b2af2fc3d0640b436462e6d4f9cb5",
                investType: 424682670,
                shareNum: 897951078,
                shareValue: 409154103,
                note: "f957525a700f4f1ca63d98f4813a070683d2a34e7f3e4a9b94267ad10131bc3abf615a1b93b746cfa31c3664a377b7dfedc0a0d9c8d544149e714c75523e40305eae1bafea944e5ebf702b605d1311576b33ffcfad04468393fe783837d496e0cbb89fdf186147869cc64e6c49c8998534d7d79eca764a4a931b60a400",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}