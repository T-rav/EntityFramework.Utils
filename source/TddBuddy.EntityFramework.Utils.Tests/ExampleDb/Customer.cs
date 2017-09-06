using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Utils.Tests.ExampleDb
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}