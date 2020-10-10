using Iceland_Moss.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceland_Moss.Model
{
    /// <summary>
    /// 運費
    /// </summary>
    public class Freight : BindableBase, ICartItem
    {
        private decimal feightCharge;
        public decimal FreightCharge
        {
            get { return feightCharge; }
            set { SetProperty(ref feightCharge, value); }
        }

        /// <summary>
        /// 運費相關邏輯
        /// </summary>
        /// <param name="orderTotal"></param>
        public void CalculateFreight(decimal orderTotal)
        {
            if (orderTotal > 80)
                FreightCharge = 0;
            else
                FreightCharge = 15;
        }
    }
}
