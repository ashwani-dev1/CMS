using CMS.Model;
using CMSDB;
using CMSDB.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CMS.Repository
{
    public class CustomerRepository:Repository<CustomerModel>
    {
        private DbContext _context;
        public CustomerRepository(DbContext context)
            : base(context)
        {
            _context = context;
        }

        public IList<CustomerModel> GetCustomer(string username)
        {
            try
            {
                using (var command = _context.CreateCommand())
                {
                    command.CommandText = $"select * from tblCustomer where Username='{username}'";
                    command.CommandType = CommandType.Text;
                    return this.ToList(command).ToList();
                }
            }
            catch (Exception)
            {
                throw;
               
            }

        }
        public CustomerModel UpdateCustomerOTP(CustomerModel model)
        {
            try
            {
                using (var command = _context.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $"update tblCustomer set OTP='{model.OTP}',IsOTPUsed='{model.IsOTPUsed}' where username='{model.Username}' ";                   
                  
                    var result = this.ToList(command).FirstOrDefault();


                    return result;
                }

            }
            catch (Exception)
            {
               
                throw;
            }


        }
        public CustomerModel OTPLogin(OTPLogin model)
        {
            try
            {
                using (var command = _context.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $"select * from tblCustomer where OTP='{model.OTP}' and userName='{model.Username}' and IsOTPUsed=0";

                    var result = this.ToList(command).FirstOrDefault();


                    return result;
                }

            }
            catch (Exception)
            {

                throw;
            }


        }
        public CustomerModel PasswordLogin(PasswordLogin model)
        {
            try
            {
                using (var command = _context.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $"select * from tblCustomer where Password='{model.Password}' and userName='{model.Username}'";

                    var result = this.ToList(command).FirstOrDefault();


                    return result;
                }

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
