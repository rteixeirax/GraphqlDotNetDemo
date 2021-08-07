using System;
using System.Collections.Generic;

namespace GraphqlDotNetDemo.Src.Data.Models
{
    public class Owner
    {
        public ICollection<Account> Accounts { get; set; }

        public string Address { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
