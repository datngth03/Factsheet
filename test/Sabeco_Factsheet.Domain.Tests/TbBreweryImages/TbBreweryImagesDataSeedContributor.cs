using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbBreweryImages;

namespace Sabeco_Factsheet.TbBreweryImages
{
    public class TbBreweryImagesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbBreweryImageRepository _tbBreweryImageRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbBreweryImagesDataSeedContributor(ITbBreweryImageRepository tbBreweryImageRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbBreweryImageRepository = tbBreweryImageRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbBreweryImageRepository.InsertAsync(new TbBreweryImage
            (
                companyId: 2118023789,
                breweryImage: "c7a44a1a8fe740a895751385acd2f7a3026d2ea3e9de4fe4ac3731bea65cd38b94aca9ab03a14e",
                imageLink: "4d681a2a23714ac39f9aa2081f8ae6230a",
                isActive: true
            ));

            await _tbBreweryImageRepository.InsertAsync(new TbBreweryImage
            (
                companyId: 2022368732,
                breweryImage: "77893ec4df",
                imageLink: "3da593c68cd04e8b9169b6489e",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}