﻿using DaySpring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaySpring.Dtos
{
    public class RoleModel: BaseEntity
    {
        public string Name { get; set; }

        public List<Member> Members { get; set; }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
