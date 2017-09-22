using structuremapSample.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace structuremapSample.Controllers
{
    public class HomeController : ApiController
    {
        private IEmailService _emailService;


        public HomeController(IEmailService emailService)
        {

            _emailService = emailService;
        }

        [HttpGet]
        public string Get()
        {
            _emailService.SendMail("welcome again");
            return "Welcome back";
         
        }
    }
}
