﻿using Sinsay.Models;

namespace Sinsay.Domain.Predefined
{
    public class PD_Roles
    {
        Role role1 = new()
        {
            Id = 1,
            Name = "Admin",
        };
        Role role2 = new()
        {
            Id = 2,
            Name = "User",
        };

        public readonly List<Role> roles;

        public PD_Roles()
        {
            roles = new()
            {
                role1, role2
            };
        }
    }
}
