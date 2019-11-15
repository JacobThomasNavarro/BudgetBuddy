using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using BudgetBuddy.Models;
using Microsoft.AspNet.Identity;

namespace BudgetBuddy.Controllers
{
    public class SMSController : TwilioController
    {
        ApplicationDbContext context;

        public SMSController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult SendSMS(User user)
        {
            
            
                var accountSid = APIKeys.TwilioaccountSid;
                var authToken = APIKeys.TwilioauthToken;
                TwilioClient.Init(accountSid, authToken);
                
                var to = new PhoneNumber("+1" + user.PhoneNumber);
                var from = new PhoneNumber("+12027409393");

                var message = MessageResource.Create(
                    to: to,
                    from: from,
                    body: "One of your wishlist goals has been met! Check back in BudgetBuddy to see what you've saved for!");
                return Content(message.Sid);
            
            return View();
        }
    }
}