﻿using System;
using System.Threading.Tasks;
using Invoicer.Common;

namespace UserService.Models
{
    public class User : IAggregateRoot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
