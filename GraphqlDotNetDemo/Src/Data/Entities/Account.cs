using System;

namespace GraphqlDotNetDemo.Src.Data.Entities
{
    public enum AccountTypeEnum
    {
        Cash,
        Savings,
        Expense,
        Income
    }

    public class Account
    {
        public string Description { get; set; }

        public Guid Id { get; set; }

        public Owner Owner { get; set; }

        public Guid OwnerId { get; set; }

        public AccountTypeEnum Type { get; set; }
    }
}
