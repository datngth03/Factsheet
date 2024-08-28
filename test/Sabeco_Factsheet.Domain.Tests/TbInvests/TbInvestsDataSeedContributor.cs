using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbInvests;

namespace Sabeco_Factsheet.TbInvests
{
    public class TbInvestsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbInvestRepository _tbInvestRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbInvestsDataSeedContributor(ITbInvestRepository tbInvestRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbInvestRepository = tbInvestRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbInvestRepository.InsertAsync(new TbInvest
            (
                branchCode: "4db87ca24add4059875b",
                branchId: 70041048,
                companyId: 1359843944,
                companyCode: "56e1eaea76174665a268",
                shareNumTotal: 740099216,
                shareValueTotal: 1070789480,
                note: "7945f798c48d4390a60e2669169a9fc9464d451117c649fbbce7f477d057c817110eebe7ac2f445db3a58027f8915cdeb34d82d49708427d95192f6852fcabe0b7e9ed8fc5ee4b9290fcab2a014c98057883a86a92b6485c882dad30797d781c74dddd9f20204ae4bb127a2ccf8c820730438ae1c9484a4382af48f332",
                docStatus: 71,
                investGroup: true,
                isActive: true
            ));

            await _tbInvestRepository.InsertAsync(new TbInvest
            (
                branchCode: "138cc923a7d144948b53",
                branchId: 1658799999,
                companyId: 1868900448,
                companyCode: "a799ee686c6d46a0a046",
                shareNumTotal: 1438433601,
                shareValueTotal: 599262234,
                note: "8bc69668c1bc4fc9b98deca646b6df59a4a81395615f47ce8a2d2e2a712b36b4657b8c55c4624bb980824e32a12d9eaa6ce913a4162448dfb9fded3576036b4d651cdd9b558c457cb8964aa5570b89289ef08a7428fa4c0c996a0b81809bbbbbd742200736464ed2b7bdf4f5f71eaa33248d234e09d848e481ead7d16f",
                docStatus: 108,
                investGroup: true,
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}