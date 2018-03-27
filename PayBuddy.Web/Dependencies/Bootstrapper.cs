using Rx.Repository;
using StructureMap;
using PayBuddy.Infrastructure.UnitofWork;
using PayBuddy.Infrastructure.UnitofWork.Interface;
using PayBuddy.Domain.UserDomain;
using PayBuddy.Domain.UserDomain.Interface;
using System.Web.Http;
using PayBuddy.Domain.AppUow;
using PayBuddy.Domain.AppUow.Interface;
using PayBuddy.Infrastructure.Security.Encryption;
using PayBuddy.Domain.AdminDomain.Interface;
using PayBuddy.Domain.AdminDomain;
using PayBuddy.Domain.CartDomain.Interface;

namespace PayBuddy.Web.Dependencies
{
    public class Bootstrapper
    {
        public static void SetUp()
        {
            IContainer container = new Container(
                            x =>
                            {
                                x.For<IRepositoryProvider>().Use<RepositoryProvider>();
                                x.For<IUow>().Use<Uow>();
                                x.For<IUserDomain>().Use<UserDomain>();
								x.For<IAppUow>().Use<AppUow>();
								x.For<IPasswordEncryption>().Use<PasswordEncryption>();
                                x.For<IAdminDomain>().Use<AdminDomain>();
                                x.For<ICartDomain>().Use<CartDomain>();
                            });

            GlobalConfiguration.Configuration.DependencyResolver = new ApplicationDependencyResolver(container);
        }
    }
}