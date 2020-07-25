using DemoArchitecture.Entity.Entities;
using System;
using System.Collections.Generic;

namespace DemoArchitecture.Entity.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBieth { get; set; }
        public string CitizenIdentityCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? WorkState { get; set; }
        public string PositionId { get; set; }
    }
}
