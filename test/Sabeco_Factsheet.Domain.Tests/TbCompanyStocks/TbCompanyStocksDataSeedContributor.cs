using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Sabeco_Factsheet.TbCompanyStocks;

namespace Sabeco_Factsheet.TbCompanyStocks
{
    public class TbCompanyStocksDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITbCompanyStockRepository _TbCompanyStockRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TbCompanyStocksDataSeedContributor(ITbCompanyStockRepository TbCompanyStockRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _TbCompanyStockRepository = TbCompanyStockRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _TbCompanyStockRepository.InsertAsync(new TbCompanyStock
            (
                companyId: 822022262,
                companyCode: "d6eac4543ced424a85d8",
                isPublicCompany: true,
                stockExchange: "a5112e9ffb",
                registrationDate: new DateTime(2004, 2, 18),
                charteredCapital: 234888953,
                parValue: 853774381,
                totalShare: 1249071888,
                listedShare: 101372347,
                description: "7d5e06678fb7494f816f898d1ab0c9d6ae83564977c44f8daee09f17fb538cd07d1f5de3f4194427a6001473cea050df833012c4f0d3428bafd947c2f09753dd16edf61aad3a46b4a033a98fde941e87baff8a8602bf4b6c90bebcfa76d8739cec4d9e538e89499e93b374a54b73db686a70df0a9d53427b81bc8ffd45",
                isActive: true,
                crt_date: new DateTime(2020, 6, 9),
                crt_user: 1706667909
            ));

            await _TbCompanyStockRepository.InsertAsync(new TbCompanyStock
            (
                companyId: 1852152813,
                companyCode: "af0c563c244e4a7ba5a8",
                isPublicCompany: true,
                stockExchange: "045975fd8e",
                registrationDate: new DateTime(2000, 5, 6),
                charteredCapital: 714289908,
                parValue: 2138194903,
                totalShare: 1641681968,
                listedShare: 2144707941,
                description: "0011f99c61b4499294b46fefee315bfe6987933454ed472096941cd45fb5be9ac68e869dc69547caa657fb907e358b409cfb8744f9274150aa1e0892051993fa7b97ee203cb94c229f2d0370b46f8db2c330fa1e3a244ca882ca1279658087ac273c41236df444d79ccd9081c769ea847f50f1db24104299964a3d7dec",
                isActive: true,
                crt_date: new DateTime(2002, 10, 27),
                crt_user: 1745389572
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}