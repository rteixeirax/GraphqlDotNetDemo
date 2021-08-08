using System;

namespace GraphqlDotNetDemo.Src.Data.Entities
{
    public enum UserStatusEnum
    {
        NotActive,
        Active,
        Blocked,
    }

    public class User
    {
        public string Email { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public Guid RoleId { get; set; }

        public UserStatusEnum Status { get; set; }
    }
}
