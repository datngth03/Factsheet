using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyBusinessDetails;

namespace Sabeco_Factsheet.TbCompanyBusinessDetails
{
    public class TbCompanyBusinessDetailsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyBusinessDetailRepository _tbCompanyBusinessDetailRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyBusinessDetailsDataSeedContributor(ITbCompanyBusinessDetailRepository tbCompanyBusinessDetailRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbCompanyBusinessDetailRepository = tbCompanyBusinessDetailRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbCompanyBusinessDetailRepository.InsertAsync(new TbCompanyBusinessDetail
            (
                parentId: 1822790001,
                registrationCode: "66794931c1",
                registrationName: "88c495bd17124979b36f4f6e01e343799f2a6eaa3490467d89d47338f39f4ef97a0f9eb9348f42b4ab6b41d87a88e2b50fe7d068b95040969bcce9c73717e76066fe2f9a0f2e46fe82fc7ae345cc5b8aa41a41dc438b445884fcaec01cb84939e348e9ae53cd4058b8184007cb4100cc7c6da5d40e3541d6936300f962",
                registrationName_EN: "b56f55cff775403db5420a5be8c9c9cf674dcc8bdabe44b891d1671a0d08b49f0ed7aebd0abb4e76a2257b1a61a9d508c4269f141fd2429c84fe97c43f7480e79943539174a54cd0823ece397e0fafaec38f73156b4d43b19f3c4a4ca6d66437585a182afb724da296449c91a47dd944a9a89d7e0b5d495daf09694db9",
                isActive: true
            ));

            await _tbCompanyBusinessDetailRepository.InsertAsync(new TbCompanyBusinessDetail
            (
                parentId: 1391495493,
                registrationCode: "34ef28013c",
                registrationName: "43a58acb4a24456887fe6b1489b442c8e301f0580c0b4daf8c4f20ed214ed3ee1a3a6759c1834681acf982d271896d9f33b399444924442595f31cbfcf15609cd25fb9bbc6914160b2867fbab96912b26e7cd70939e84de19dc4bec5e955e4d9949015f2655b49c78202bdaff0184dcfa0a4a88647964e8e880797cb92",
                registrationName_EN: "3e64e6a819664d51a4c155f1ce4611b112854ebf69ff4e518ca68dc8fa8e1f4a94cf0e50c68945a3a15336b4af79e36a32169207da294839b32ded291b30d4f48a4e2f049f364599a92682dadf507b1a221906f99cb640cb836f3988a9c9387d9fc07ebae1cc44f395198509baf2789c55dbcd0be11f4fd2be37321b0e",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}