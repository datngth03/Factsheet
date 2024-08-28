using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbNationalities;

namespace Sabeco_Factsheet.TbNationalities
{
    public class TbNationalitiesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbNationalityRepository _tbNationalityRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbNationalitiesDataSeedContributor(ITbNationalityRepository tbNationalityRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbNationalityRepository = tbNationalityRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbNationalityRepository.InsertAsync(new TbNationality
            (
                code: "8a3",
                code2: "98",
                name_en: "f88e402c2d5045c494cda9e5adf0797f76593cd869ee4a8d952d6d4ab68d6a60f26818e6a21646f5805a22799039f336488a407a3bbe4edb8a1f7934d2f944e89c04485fb0cd4c6182cf886092414c32d2c0e994bb124abca470eb756bafd25e55902515710a4074b4f56f7cb341a77f554dd6e5979848ab9c2e069191414a9",
                name_vn: "6713dd2f67c34536bfa9e410130dff6ce034e7646aa04ad882b84c3eff05ec2d6d567fd62756460d91f3f497c76ce2d769829d455e844e9bab9f698a8f35de4a03db818c60254073855d6241ee9583000ad77bce29044f13816ba93bb029f00c566a550d5d4442f3adb818aa54bc1f50d8483893b3c64f6bae5c4cf5d2f6afb",
                isActive: true
            ));

            await _tbNationalityRepository.InsertAsync(new TbNationality
            (
                code: "467",
                code2: "f4",
                name_en: "ed1df3c25c01465e80c48dc94970c74c37b1b1c6f37b4607a4a030b98eb1b4c3ff7b5032a80e4b59aad7ee9681410ba0e458623aab51405086c183fe22685c71dbf80970665d463c99d3d7882551d508ea3eeba536bf4993bea9bb4897c424fbc7408680051f4f1cacde481bcb7720861420284133654a53a916cd8e263aca7",
                name_vn: "d7f3c3af5c6148b091c7ddffa1ba17fcf12779a523e64f1c9ed092a6214f883cf5290de0d1184f1bb584f58bc908490524f47a7388f24f33aa889274405ca07586dd27f3036c4423b2cb61b890413f8fe89e030392084e1f90a213576bafd580918b3768becb4dfbbdc638cc45aa390f0714ac7a2fa1420ab8b28646fa29966",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}