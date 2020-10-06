using Ninject.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Interfaces;
using SGBank.Data;
using System.Configuration;

namespace SGBank.BLL
{
    public class NinjectManager
    {
        public class Bindings : NinjectModule
        {
            public override void Load()
            {
                string mode = ConfigurationManager.AppSettings["Mode"].ToString();

                switch (mode)
                {
                    case "FreeTest":
                        Bind<IAccountRepository>().To<FreeAccountTestRepository>();
                        break;
                    case "BasicTest":
                        Bind<IAccountRepository>().To<BasicAccountTestRepository>();
                        break;
                    case "PremiumTest":
                        Bind<IAccountRepository>().To<PremiumAccountTestRepository>();
                        break;
                    case "FileAccount":
                        Bind<IAccountRepository>().To<FileAccountRepository>();
                        break;
                    default:
                        throw new Exception("Mode value in app config is not valid");
                }            
            }
        }
    }

}
