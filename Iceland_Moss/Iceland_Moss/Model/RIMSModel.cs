using System;
using System.Collections.Generic;
using System.Text;


namespace Iceland_Moss.Model
{
    public class RIMSModel
    {
        public class MaterialMasterDTO
        {
            //v
            public int MatId { get; set; }
            //v
            public string MatName { get; set; }
            //v
            public bool VirtualMat { get; set; }
            public string MatNo { get; set; }

            public string FETNo { get; set; }
            //v
            public string ACNo { get; set; }

            public string DENo { get; set; }
            //v
            public string OriNo { get; set; }

            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string SubMaterialID { get; set; }

            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string SubMaterialName { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string Inventory { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string IsValid { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string IsDoValidation { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string ValidationErrors { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string ValidationErrorMessage { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string DB_APPNO { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string DB_CRDAT { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string DB_CRUSR { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string DB_TRDAT { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string DB_TRUSR { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string Changed { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string IsTruncated { get; set; }
            /// <summary>
            /// 20200423建立之RIMS專用
            /// </summary>
            public string TruncatedFieldNames { get; set; }


            public int CatId { get; set; }

            public int CatRootId { get; set; }

            public bool InIMEI { get; set; }

            public bool InMSN { get; set; }


            public decimal ExchangePrice { get; set; }

            public decimal ExchangeTaxPrice { get { return Math.Round(ExchangePrice / 10, 0, MidpointRounding.AwayFromZero) * 10; } }

            public decimal StockPrice { get; set; }

            public decimal StockTaxPrice { get { return Math.Round(StockPrice / 10, 0, MidpointRounding.AwayFromZero) * 10; } }

            public decimal CompensatePrice { get; set; }

            public decimal CompensateTaxPrice { get { return Math.Round(CompensatePrice / 10, 0, MidpointRounding.AwayFromZero) * 10; } }

            public decimal ExchangeSellPrice { get; set; }
            public decimal StockSellPrice { get; set; }
            public decimal CompensateSellPrice { get; set; }

            public decimal StorePrice { get; set; }

            public decimal StockPriceFactor { get; set; }

            public decimal ExchangePriceFactor { get; set; }

            public byte SelfRepairLevel { get; set; }

            public decimal AsuExchangePrice { get; set; }

            public decimal AsuStockPrice { get; set; }

            //v
            public int RealQty { get; set; }
            //v
            public int ReserveQty { get; set; }

            public decimal StockQuotePrice { get { return Math.Round(StockPrice * StockPriceFactor, 0, MidpointRounding.AwayFromZero); } }

            public decimal ExchangeQuotePrice { get { return Math.Round(ExchangePrice * ExchangePriceFactor, 0, MidpointRounding.AwayFromZero); } }

            public int SubClass { get; set; } //中類

            public bool WholePart { get; set; }

            public bool IsApple { get; set; } //是否為Apple

            public bool Consumable { get { return SubClass == 2141; } } //耗材類的中類代碼是2141

            public string GsxComponentCode { get; set; }

            public bool GsxSerialized { get; set; }

            public bool FetBorrow { get; set; }
        }
    }
}