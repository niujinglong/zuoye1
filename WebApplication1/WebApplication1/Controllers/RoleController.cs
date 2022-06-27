﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RbacApplication;
using RbacApplication.Role;
using RbacRepository.FenYe;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService role;

        public RoleController(IRoleService role)
        {
            this.role = role;
        }

        [HttpPost]
        public IActionResult Add(RoleDto dto)
        {
            return Ok(role.Add(dto));
        }

        [HttpGet]
        public IActionResult Show()
        {
            return new JsonResult(role.GetAll());
        }

        [HttpGet]
        public IActionResult GetFen([FromQuery] TiaoJian t)
        {
            return new JsonResult(role.GetFen(t));
        }

        [HttpGet]
        public IActionResult GeiId(int id)
        {
            return new JsonResult(role.GetById(id));
        }

        [HttpDelete]
        public IActionResult Del(int id)
        {
            return Ok(role.Delete(id));
        }

        [HttpPut]
        public IActionResult Upd(RoleDto r)
        {
            return Ok(role.Update(r));
        }
    }
}
