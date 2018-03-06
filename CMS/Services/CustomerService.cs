using CMS.Model;
using CMS.Models;
using CMS.Repository;
using CMS.Services;
using CMSDB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly IConfiguration configuration;
        private IConnectionFactory connectionFactory;
        public CustomerService(IConfiguration config)
        {
            configuration = config;
        }
        public IList<CustomerModel> GetUsers(string userName)
        {
            try
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                connectionFactory = ConnectionHelper.GetConnection(connectionString);

                var context = new DbContext(connectionFactory);

                var userRep = new CustomerRepository(context);

                return userRep.GetCustomer(userName);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public CustomerModel UpdateOTP(string userName, string OTP, bool isUsed)
        {
            try
            {
                var model = new CustomerModel();
                model.Username = userName;
                model.OTP = OTP;
                model.IsOTPUsed = isUsed;
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                connectionFactory = ConnectionHelper.GetConnection(connectionString);

                var context = new DbContext(connectionFactory);

                var userRep = new CustomerRepository(context);

                return userRep.UpdateCustomerOTP(model);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
