﻿using AutoMapper;
using Rbac.Entity;
using RbacApplication.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication
{
    public class AutomappperConfig:Profile
    {
        public AutomappperConfig()
        { 
            CreateMap<RoleDto,Rbac.Entity.Role>().ReverseMap();
            CreateMap<AdminDto,Rbac.Entity.Admin>().ReverseMap();

        }
    }
}
