using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDto.Models;

namespace BrokerService.Interfaces
{
    public interface IBroker
    {
        /// <summary>
        /// Sell an Asset by quantity
        /// </summary>
        /// <param name="quantity">Number of asset sold, for example, for a stock, number of shares sold</param>
        void SellAsset(int quantity);
    }
}
