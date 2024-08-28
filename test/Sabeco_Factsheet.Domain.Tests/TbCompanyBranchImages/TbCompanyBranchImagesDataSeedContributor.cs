using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyBranchImages;

namespace Sabeco_Factsheet.TbCompanyBranchImages
{
    public class TbCompanyBranchImagesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyBranchImageRepository _tbCompanyBranchImageRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyBranchImagesDataSeedContributor(ITbCompanyBranchImageRepository tbCompanyBranchImageRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyBranchImageRepository = tbCompanyBranchImageRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyBranchImageRepository.InsertAsync(new TbCompanyBranchImage
            (
                companyId: 1406552549,
                branchImage: "8dfba3c8e177462eaef8468625fbf4c5b2087ce472f5472189ac3755a01a7cccccff4b6ca0404b8abaf368437bb2145b72",
                imageLink: "c01ba7bb14fd496d99f6d2a28ae94f53051d99b4d2d44487a18c93fc6a59b628ea684c921f6a4c338269628",
                isActive: true
            ));

            await _tbCompanyBranchImageRepository.InsertAsync(new TbCompanyBranchImage
            (
                companyId: 132656186,
                branchImage: "67f7d085a71a4a7682061ecf2b95206bc0761e2e2b274fe895652aebbd1d041fbc",
                imageLink: "b3fd94744abf4ade997d0332cd75bbd05155a83e9b5d40518eefc9a3c7a96fb072e9b5916b7041148b4a2b556cde",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}