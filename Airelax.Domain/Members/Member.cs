using System;
using Airelax.Domain.DomainObject;
using Airelax.Domain.Members.Defines;

namespace Airelax.Domain.Members
{
    public class Member : AggregateRoot<int>
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string AddressDetail { get; set; }
        public string Phone { get; set; }
        public bool IsPhoneVerified { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime RegisterTime { get; set; }


        public Member()
        {
            IsDeleted = false;
            RegisterTime = DateTime.Now;
            IsPhoneVerified = false;
            IsEmailVerified = false;
            Gender = Gender.Other;
        }

        // public void VerifyPhone()
        // {
        //     IsPhoneVerified = true;
        // }
        // public void VerifyEmail()
        // {
        //     IsEmailVerified = true;
        // }
    }
}