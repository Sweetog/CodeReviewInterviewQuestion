using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingService.Implementations;
using AccountingService.Interfaces;
using AccountingService.Utility;
using AppDto;
using BrokerService.Implementations;
using BrokerService.Interfaces;
using BrokerService.Utility;
using DataAccessLayer.Implementations;
using DataAccessLayer.Implementations.Persist;
using DataAccessLayer.Interfaces;
using DataModels;
using Ninject.Modules;

namespace AppService.BindingConfiguration
{
    public class BindingsModule : NinjectModule
    {
        private AccountingType acType;

        public BindingsModule(AccountingType accountingType)
        {
            acType = accountingType;
        }

        public override void Load()
        {
            Bind<IRepository<DataModels.Lot>>().To<Repository<DataModels.Lot>>().InSingletonScope();
            Bind<IPersistLots>().To<PersistLots>().InSingletonScope();
            Bind<ICostAccountantUtility>().To<CostAccountantUtility>();
            Bind<IBrokerUtility>().To<BrokerUtility>();

            switch (acType)
            {
                case AccountingType.FIFO:
                    Bind<ICostAccountant>().To<CostAccountantFifo>();
                    Bind<IBroker>().To<BrokerFifo>();
                    break;
                case AccountingType.LILO:
                    Bind<ICostAccountant>().To<CostAccountantLilo>();
                    Bind<IBroker>().To<BrokerLilo>();
                    break;
                default:
                    Bind<ICostAccountant>().To<CostAccountantFifo>();
                    Bind<IBroker>().To<BrokerFifo>();
                    break;
            }

        }
    }
}
