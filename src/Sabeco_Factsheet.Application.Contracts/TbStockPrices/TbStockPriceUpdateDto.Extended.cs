namespace Sabeco_Factsheet.TbStockPrices
{
    public class TbStockPriceUpdateDto : TbStockPriceUpdateDtoBase
    {
        //Write your custom code here...
        public bool IsChanged { get; set; }
        public int Idx { get; set; }
    }
}