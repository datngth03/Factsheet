using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbFileUploads;

namespace Sabeco_Factsheet.TbFileUploads
{
    public class TbFileUploadsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbFileUploadRepository _tbFileUploadRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbFileUploadsDataSeedContributor(ITbFileUploadRepository tbFileUploadRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tbFileUploadRepository = tbFileUploadRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tbFileUploadRepository.InsertAsync(new TbFileUpload
            (
                companyId: 156202326,
                personId: 1558737991,
                fileName: "9b9e93cf0f6c4f218af6c513459d4d2c638a233a03c14a",
                fullFileName: "b21582d26b82",
                fileLink: "0a5c15af9f874293a4658e8b22cd6a86ebf55495fa72449e8a31fcf68789f941a28",
                uploadDate: new DateTime(2004, 2, 1),
                userUpload: 1407705014,
                note: "4d73a4c9b1a04e06b8f74e84f86f1bc63e813f158c4b49e980d2a47cb4f2e6c5dde",
                isActive: true
            ));

            await _tbFileUploadRepository.InsertAsync(new TbFileUpload
            (
                companyId: 1364112196,
                personId: 1111817520,
                fileName: "83d98b2c11aa4436ad2b458626fcd775ded70392be28466097bf6af7",
                fullFileName: "cb22bcdd18ef40e58e",
                fileLink: "5dc82899dcf94fc4902e2a67",
                uploadDate: new DateTime(2012, 8, 10),
                userUpload: 410740502,
                note: "b8b460bc",
                isActive: true
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}