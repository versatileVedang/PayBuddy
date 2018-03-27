using PayBuddy.Domain.AdminDomain.Interface;
using PayBuddy.Domain.AppUow.Interface;
using PayBuddy.Domain.CartDomain.Interface;
using PayBuddy.Domain.UserDomain.Interface;
using PayBuddy.Infrastructure.UnitofWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PayBuddy.Web.Controllers.api
{
    public class ApiBaseController : ApiController, IDisposable
	{

		public IUow Uow { get; set; }

		public IAppUow AppUow { get; set; }

        public IUserDomain UserDomain { get; set; }

        public IAdminDomain AdminDomain { get;  set; }

        public ICartDomain CartDomain { get;set; }

        void IDisposable.Dispose()
		{
			this.Dispose(true);
		}
		public static string GetyyyyMMddString()
		{
			return DateTime.UtcNow.ToString("yyyyMMdd");
		}
	}
}
