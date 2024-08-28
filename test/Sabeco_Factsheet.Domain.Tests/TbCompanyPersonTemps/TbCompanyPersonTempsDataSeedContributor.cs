using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyPersonTemps;

namespace Sabeco_Factsheet.TbCompanyPersonTemps
{
    public class TbCompanyPersonTempsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyPersonTempRepository _tbCompanyPersonTempRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyPersonTempsDataSeedContributor(ITbCompanyPersonTempRepository tbCompanyPersonTempRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyPersonTempRepository = tbCompanyPersonTempRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyPersonTempRepository.InsertAsync(new TbCompanyPersonTemp
            (
                idCompanyPerson: 2044803175,
                branchCode: "ddb480e473",
                companyId: 754865629,
                personId: 1031966112,
                positionId: 1819095046,
                fromDate: new DateTime(2012, 6, 22),
                toDate: new DateTime(2014, 10, 14),
                positionCode: "b0cb569598d4493991f4",
                personalValue: 1856752432,
                personalSharePercentage: 1310328170,
                ownerValue: 241434207,
                representativePercentage: 462497789,
                note: "b19a8dce534643daabe9d785c15c7678232790d0dfbe4831954b8a5501ed647cd6e9663f8d2441f890a9b72af0dda9b537b8a2ecd4fb4cb6aa4ef09b4e7b34b2ea537d61b17b4395b4c820462a0646cb159896f527454ab8b297bc66a196ff427bec549883b14fda82f13dcc708b7f04d195b0043f7d49abbdbd41d373",
                isActive: true
            ));

            await _tbCompanyPersonTempRepository.InsertAsync(new TbCompanyPersonTemp
            (
                idCompanyPerson: 887589421,
                branchCode: "2e4b150b49",
                companyId: 37052814,
                personId: 839788527,
                positionId: 1568996630,
                fromDate: new DateTime(2020, 4, 1),
                toDate: new DateTime(2011, 2, 21),
                positionCode: "bd41a5ac58e74f6fb3a4",
                personalValue: 755960817,
                personalSharePercentage: 55665964,
                ownerValue: 2036591365,
                representativePercentage: 276811722,
                note: "8185ebcd703c406f947f10cd8d7aefa11b83547b91184bdcaf2bc7baf50d42b0a208471772504a3a8314debdf06f084261a64f702ca54fff8c8a2ff9e6f51e5fa7d1a702b03d4173a5bdce248be07eabd105da96cf6b4bd0aac87dd7d1cf0162affad15642324abebcfe194739290aae9ed2e7aa55db4dc6aedf9395f4",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}