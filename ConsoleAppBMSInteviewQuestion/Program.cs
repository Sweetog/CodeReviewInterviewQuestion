using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AccountingService;
using AppDto;
using AppDto.Models;
using AppService;

namespace ConsoleAppBMSInteviewQuestion
{
    class Program
    {
        static void Main(string[] args)
        {

            AppWorker.Start(AccountingType.FIFO);

            //init data to "database"
            AppWorker.AppPersist.CreateLot(new Lot() { PricePerShare = 20, CurrentQuantity = 100, TransactionDate = new DateTime(2016, 4, 1) });
            AppWorker.AppPersist.CreateLot(new Lot() { PricePerShare = 30, CurrentQuantity = 150, TransactionDate = new DateTime(2016, 5, 1) });
            AppWorker.AppPersist.CreateLot(new Lot() { PricePerShare = 40, CurrentQuantity = 100, TransactionDate = new DateTime(2016, 6, 1) });

            Console.WriteLine("Please enter sale quantity and price in the form q,p:");
            var input = Console.ReadLine().Split(',');

            var quantity = int.Parse(input[0]);
            var salePrice = decimal.Parse(input[1]);

            AppWorker.Broker.SellAsset(quantity);

            var costBasicSharesSold = AppWorker.Accountant.CostBasisSharesSold();
            var totalProfitLoss = (salePrice*quantity) - (costBasicSharesSold*quantity);

          

            Console.WriteLine("Cost basis of sold shares: {0:C}", costBasicSharesSold);
            Console.WriteLine("Cost basis of remaining assets: {0:C}", AppWorker.Accountant.CostBasis());
            Console.WriteLine("Total profit/loss on tranasction: {0:C}", totalProfitLoss);
            Console.ReadLine();

        }
    }
}
