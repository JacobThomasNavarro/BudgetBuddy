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

namespace BudgetBuddy.Controllers
{
    public class SMSController : TwilioController
    {
        ApplicationDbContext context;

        public SMSController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult SendSMS(WishList wishList)
        {
            if (wishList.wishListId == wishList.wishListPrice)//we will change this soon to wishlist price == saving price
            {
                var accountSid = APIkeys.TwilioaccountSid;
                var authToken = APIkeys.TwilioauthToken;
                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber(APIkeys.MySecretNumber);
                var from = new PhoneNumber("+12027409393");

                var message = MessageResource.Create(
                    to: to,
                    from: from,
                    body: "One of your wishlist goals has been met! Check back in BudgetBuddy to see what you've saved for!");
                return Content(message.Sid);
            }
            return View(wishList);
        }
    }
}