using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyPersons;

namespace Sabeco_Factsheet.TbCompanyPersons
{
    public class TbCompanyPersonsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyPersonRepository _tbCompanyPersonRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyPersonsDataSeedContributor(ITbCompanyPersonRepository tbCompanyPersonRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyPersonRepository = tbCompanyPersonRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyPersonRepository.InsertAsync(new TbCompanyPerson
            (
                branchCode: "46a1bcc60a",
                companyId: 276563033,
                personId: 1543600424,
                positionId: 537320375,
                fromDate: new DateTime(2012, 6, 4),
                toDate: new DateTime(2009, 5, 20),
                positionCode: "a9ce3ac63be343d58444",
                personalValue: 1749278234,
                personalSharePercentage: 1488201388,
                ownerValue: 159954418,
                representativePercentage: 1164808958,
                note: "fb4d60376b9444e7bcb5c5f996c81d8d087827a1b557432d8e4976282478ebc197623463b7544837b626b34403a0097b65f2f647d1554aceadacbdfd2a9d4bd427806a8fc8544c03b5ef26419fe30c32b25c8db26571415289776a270695859855f9acc79463402498975f1b2f4fdbaa650315653c51493b80548ae2d6",
                isActive: true
            ));

            await _tbCompanyPersonRepository.InsertAsync(new TbCompanyPerson
            (
                branchCode: "de3964bc1b",
                companyId: 1953390011,
                personId: 1212361485,
                positionId: 1919381473,
                fromDate: new DateTime(2018, 10, 23),
                toDate: new DateTime(2008, 6, 16),
                positionCode: "031601faeb574fd383c6",
                personalValue: 1792048126,
                personalSharePercentage: 184876653,
                ownerValue: 1295463008,
                representativePercentage: 576858790,
                note: "28acc915bcef4854aa93f08281c045778bba5d387f9346e58fe9be02f7ff6eed61e7f589be2b4b24aac76fe9289002a5d7d16b37de064666b633410c653cc4281f22e48f2be9498f95bb1f6edc2bbe03f352ef7a6091454eabdb8862cbf77fe2da625115b6ac49d59977487d08f29e436dfb02fe4b4142a29506db7ec7",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}