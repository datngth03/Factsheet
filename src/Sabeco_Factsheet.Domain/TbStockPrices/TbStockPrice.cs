using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Sabeco_Factsheet.TbStockPrices
{
    public abstract class TbStockPriceBase : Entity<int>
    {
        [NotNull]
        public virtual string StockCode { get; set; }

        public virtual DateTime? StockDate { get; set; }

        public virtual decimal? LimitUpPrice { get; set; }

        public virtual decimal? LimitDownPrice { get; set; }

        public virtual decimal? ReferencePrice { get; set; }

        public virtual decimal? SaleQty1 { get; set; }

        public virtual decimal? SalePrice1 { get; set; }

        public virtual decimal? SaleQty2 { get; set; }

        public virtual decimal? SalePrice2 { get; set; }

        public virtual decimal? SaleQty3 { get; set; }

        public virtual decimal? SalePrice3 { get; set; }

        public virtual decimal? BuyQty1 { get; set; }

        public virtual decimal? BuyPrice1 { get; set; }

        public virtual decimal? BuyQty2 { get; set; }

        public virtual decimal? BuyPrice2 { get; set; }

        public virtual decimal? BuyQty3 { get; set; }

        public virtual decimal? BuyPrice3 { get; set; }

        public virtual decimal? TransactionPrice { get; set; }

        public virtual decimal? TransactionQty { get; set; }

        public virtual decimal? TotalQty { get; set; }

        public virtual bool? IsActive { get; set; }

        public virtual DateTime? crt_date { get; set; }

        public virtual int? crt_user { get; set; }

        protected TbStockPriceBase()
        {

        }

        public TbStockPriceBase(string stockCode, DateTime? stockDate = null, decimal? limitUpPrice = null, decimal? limitDownPrice = null, decimal? referencePrice = null, decimal? saleQty1 = null, decimal? salePrice1 = null, decimal? saleQty2 = null, decimal? salePrice2 = null, decimal? saleQty3 = null, decimal? salePrice3 = null, decimal? buyQty1 = null, decimal? buyPrice1 = null, decimal? buyQty2 = null, decimal? buyPrice2 = null, decimal? buyQty3 = null, decimal? buyPrice3 = null, decimal? transactionPrice = null, decimal? transactionQty = null, decimal? totalQty = null, bool? isActive = null, DateTime? crt_date = null, int? crt_user = null)
        {

            Check.NotNull(stockCode, nameof(stockCode));
            Check.Length(stockCode, nameof(stockCode), TbStockPriceConsts.StockCodeMaxLength, 0);
            StockCode = stockCode;
            StockDate = stockDate;
            LimitUpPrice = limitUpPrice;
            LimitDownPrice = limitDownPrice;
            ReferencePrice = referencePrice;
            SaleQty1 = saleQty1;
            SalePrice1 = salePrice1;
            SaleQty2 = saleQty2;
            SalePrice2 = salePrice2;
            SaleQty3 = saleQty3;
            SalePrice3 = salePrice3;
            BuyQty1 = buyQty1;
            BuyPrice1 = buyPrice1;
            BuyQty2 = buyQty2;
            BuyPrice2 = buyPrice2;
            BuyQty3 = buyQty3;
            BuyPrice3 = buyPrice3;
            TransactionPrice = transactionPrice;
            TransactionQty = transactionQty;
            TotalQty = totalQty;
            IsActive = isActive;
            this.crt_date = crt_date;
            this.crt_user = crt_user;
        }

    }
}