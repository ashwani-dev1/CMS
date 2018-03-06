using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Model;
using CMS.Models;
using CMS.Repository;
using CMS.Services;
using CMSDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    public class ManageCustomerController : Controller
    {
        private readonly IConfiguration configuration;
        private IConnectionFactory connectionFactory;
        private ICustomerService customerService;
        public ManageCustomerController(IConfiguration config, ICustomerService customerService)
        {
            configuration = config;
            this.customerService = customerService;
        }
        [HttpGet("[action]")]
        public OTPMessage SendSMS(string userName)
        {

            OTPMessage oMessage = new OTPMessage();
            const string accountSid = "ACedd85e0a7458ffa36d3b957ab5df33d7";
            const string authToken = "88002d9d184903e55164ad373b1a0cfc";
            TwilioClient.Init(accountSid, authToken);
            Random generator = new Random();
            String otp = generator.Next(0, 1000000).ToString("D6");

            try
            {
                var customer = customerService.GetUsers(userName);
                if (customer.Count > 0)
                {
                    var to = new PhoneNumber(customer[0].Country + customer[0].PhonePersonal);
                    var message = MessageResource.Create(
                                to,
                                from: new PhoneNumber("+15592967092"), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ).  
                                body: $"Hello {userName} !!Your CMS verification code is:" + otp);
                    customerService.UpdateOTP(userName, otp, false);
                    oMessage.Message = "Verification code has been sent to your register mobile number";
                    return oMessage;
                }
                else
                {
                    oMessage.Message = "User not found.";
                    return oMessage;
                }
            }
            catch (Exception ex)
            {

                oMessage.Message = ex.Message;
                return oMessage;
            }


        }
        [HttpPost("[action]")]
        public OTPLogin OTPLogin([FromBody]OTPLogin login)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                connectionFactory = ConnectionHelper.GetConnection(connectionString);

                var context = new DbContext(connectionFactory);

                var userRep = new CustomerRepository(context);
                var result = userRep.OTPLogin(login);
                if (result != null)
                {
                    customerService.UpdateOTP(login.Username, login.OTP, true);
                    login.Message = "success";
                    return login;
                }
                else
                {
                    login.Message = "Customer does not exist.";
                    return login;
                }
            }
            catch (Exception ex)
            {
                login.Message = ex.Message;
                return login;
            }
        }
        [HttpPost("[action]")]
        public PasswordLogin PasswordLogin([FromBody]PasswordLogin login)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                connectionFactory = ConnectionHelper.GetConnection(connectionString);

                var context = new DbContext(connectionFactory);

                var userRep = new CustomerRepository(context);
                var result = userRep.PasswordLogin(login);
                if (result != null)
                {
                   
                    login.Message = "success";
                    return login;
                }
                else
                {
                    login.Message = "Customer does not exist.";
                    return login;
                }
            }
            catch (Exception ex)
            {
                login.Message = ex.Message;
                return login;
            }
        }

    }
}