using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyMajors;

namespace Sabeco_Factsheet.TbCompanyMajors
{
    public class TbCompanyMajorsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyMajorRepository _tbCompanyMajorRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyMajorsDataSeedContributor(ITbCompanyMajorRepository tbCompanyMajorRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyMajorRepository = tbCompanyMajorRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyMajorRepository.InsertAsync(new TbCompanyMajor
            (
                companyId: 414931707,
                shareHolderMajor: "28c61244c3c241f4b5681d663e5ac36928667c76bd3b4d1cb056",
                shareHolderType: "3fb688493c7144f782f8",
                fromDate: new DateTime(2019, 10, 27),
                toDate: new DateTime(2015, 8, 2),
                shareHolderValue: 609260077,
                shareHolderRate: 324201020,
                note: "8a3731bdf508402b89b9371ee669fd9379ddfa0c05c54179bdd3c72825752964749852c1b2034b7b93b7f60317c2f3bdd55c702c0c3244d7bab850bd5adfedf28f6f3f62010c49d6aafdb6057cec4e17b3ccba268ae34781a293336d84ffbf3fa14f110eaa8b42d4a55514de3b9ad192c08c0cedb8564a1e8f0e1b41a8",
                isActive: true,
                classId: 1528306893
            ));

            await _tbCompanyMajorRepository.InsertAsync(new TbCompanyMajor
            (
                companyId: 931385175,
                shareHolderMajor: "a68ee774478d47e88fe831eca4b0fc5fc0a57ef33e494c7db867358a226cd52574c838d",
                shareHolderType: "96bd470ac1174022b5d9",
                fromDate: new DateTime(2007, 7, 2),
                toDate: new DateTime(2002, 11, 15),
                shareHolderValue: 578090922,
                shareHolderRate: 192878743,
                note: "731f43c5458b4b1bb667409399f57ee07e7c321ffbb042f39db18c6fc02b45d25a0d3ccba3114e5483aa4519b4765965a214688bd1724376afe637fd3e056486821913ba82f64d899f479514e1047b601831f9deceb04e8a9c67efcd0d710cb23c25fb4292cb4802b47e8c0fb181aa91bef430a2ebfe4936bbd260e499",
                isActive: true,
                classId: 315099052
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}