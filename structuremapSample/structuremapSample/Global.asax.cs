using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using StructureMap.Graph;
using Hangfire.StructureMap;
using Hangfire;
using structuremapSample.Utilities;

namespace structuremapSample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private BackgroundJobServer _backgroundJobServer;

        protected void Application_Start()
        {


            System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);

            Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage(@"Server=XXXXXXX\SQLEXPRESS; Database=Hangfire;uid=XXXX\XXXX;Password=XXXXXX;Integrated Security=true");
            

            _backgroundJobServer = new BackgroundJobServer();
            //BackgroundJob or recurring
            //BackgroundJob.Enqueue<EmailService>(myService => myService.SendMail("my JSON object"));
            RecurringJob.AddOrUpdate<EmailService>(myService => myService.SendMail("my mail"), Cron.Minutely);
        }
    }
}
