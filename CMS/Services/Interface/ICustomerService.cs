using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public interface ICustomerService
    {
        IList<CustomerModel> GetUsers(string userName);
        CustomerModel UpdateOTP(string userName, string OTP, bool isUsed);
    }
}
