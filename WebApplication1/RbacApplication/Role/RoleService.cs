﻿using AutoMapper;
using Rbac.Entity;
using RbacRepository;
using RbacRepository.MenuRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication.Role
{
    public class RoleService : BaseService<Rbac.Entity.Role, RoleDto>, IRoleService
    {
        private readonly IRoleDto baseService;
        private readonly IMenuRoleRepository menuRoleRepository;
        private readonly IMapper mapper;

        public RoleService(IRoleDto baseService, IMenuRoleRepository menuRoleRepository, IMapper mapper) : base(baseService, mapper)
        {
            this.baseService = baseService;
            this.menuRoleRepository = menuRoleRepository;
            this.mapper = mapper;
        }

        public int SavePermission(PermissionDto permission)
        {
            var ids = permission.MenuId.Select(m => new MenuRole { MenuId = m, RoleId = permission.RoleId }).ToList();
            return menuRoleRepository.Add(ids);

        }
    }
}
