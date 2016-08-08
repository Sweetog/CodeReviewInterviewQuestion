using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AccountingService;
using AccountingService.Interfaces;
using AppDto;
using AppDto.Models;
using AppService.BindingConfiguration;
using AutoMapper;
using BrokerService.Interfaces;
using DataAccessLayer.Interfaces;
using Ninject;

namespace AppService
{
    public static class AppWorker
    {
        public static AppPersist AppPersist { get; private set; }
        //public static AccountingWorker AccountingWorker { get; private set; }

        public static ICostAccountant Accountant { get; private set; }

        public static IBroker Broker { get; private set; }



        public static void Start(AccountingType accountingType)
        {
            //setup ninject
            var kernel = new StandardKernel(new NinjectSettings() { InjectNonPublic = true });
            //kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Load(new BindingsModule(accountingType));

            //automapper
            AutoMapperConfiguration.Configure();

            AppPersist = new AppPersist(kernel.Get<IPersistLots>());

            Accountant = kernel.Get<ICostAccountant>();

            Broker = kernel.Get<IBroker>();
        }
    }
}
