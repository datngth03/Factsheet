using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbRoles;

namespace Sabeco_Factsheet.TbRoles
{
    public class TbRolesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbRoleRepository _tbRoleRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbRolesDataSeedContributor(ITbRoleRepository tbRoleRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbRoleRepository = tbRoleRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbRoleRepository.InsertAsync(new TbRole
            (
                code: "2fa0376008ef4248b9ca",
                name: "a01145d1f1c94391bc4d6949df4002ca80fb3a77095c43d1bb5c742b80601db14c11671268ec44c3afdabb1e26490d19493746167ff9408ab89f891c2b7ed7025367094e868b4c21a3c61c8290cda3811dfa30bec55d4a87b3fc6d8a74cbadb4775e71b947ba444c9c72195e2f1bbc50882c220b82ef4df5a25c80abba",
                description: "f65a837533114c709bc25cbe6faf1a2d6495a945662c46adb466785893718e9d383ff85ebd62403fb84ebbcb641c83c9e6e70b5178084a99ab74587f1598dd3abd907be7b0104d04999775f3e9eed7709a652210c688466985622428793d0957ba3ce84a1da5469495bf9b9049d3ed5ad1bc532c16df48d39011f181c0",
                isActive: true
            ));

            await _tbRoleRepository.InsertAsync(new TbRole
            (
                code: "a452d68e05134393a7f1",
                name: "b4d3a85064184883b9703cfef16df95acb3d70bb6c1a4bf2925e0cabec12ae23df4d8b102a3b4ef28e9a8ef6c088f09f27fa6496a9ec4af4b4b857115fbd0746096d36593c3e4e9db93735d567742b0cd96f1c30a0d94292b5227d23b3b332ee724cbd20e7bf4b57a99a254997c0c0199e6adbb0cd5047f6b1629ad674",
                description: "f1242ea51d6f4ff59937668600258431e212cf3599fc4a1fa3f54258577abb061cee3f20e4304ae78cf448ae1030fc09f56445eff4d14050b16de82c245c88c3e2185a0113014d288af89dabc8f215cafbc09c6d7df7454198e6a7d0f3f91582fe3914120158473f8edea320e969b64e09442ea634aa4c0eb2a45eac12",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}