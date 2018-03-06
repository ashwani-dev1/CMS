using System;

namespace CMS.Model
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string OTP { get; set; }
        public bool IsOTPUsed { get; set; }
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? Gender { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string HouseNumber { get; set; }
        public int? Zip { get; set; }
        public string Country { get; set; }
        public string PhoneWork { get; set; }
        public string PhonePersonal { get; set; }
        public string EmailAddress { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string AccountNo { get; set; }
        public int? RoleId { get; set; }
        public string CompanyName { get; set; }
    }
    public class OTPLogin
    {
        public string Username { get; set; }
        public string OTP { get; set; }
        public string Message { get; set; }
    }
    public class PasswordLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
    }
}
