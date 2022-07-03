using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RbacApplication.Admin;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminsController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(RbacApplication.Admin.AdminDto dto)
        {
            return Ok(adminService.Register(dto));
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            return Ok(adminService.Login(dto));
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="Pindex"></param>
        /// <param name="Psize"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Page(int Pindex = 1, int Psize = 2)
        {
            return Ok(adminService.Page(Pindex, Psize));
        }

        //[HttpPost]
        //public IActionResult Add(AdminDto dto)
        //{
        //    return Ok(adminService.Add(dto));
        //}

        //[HttpGet]
        //public IActionResult Show()
        //{
        //    return new JsonResult(adminService.GetAll());
        //}

        //[HttpGet]
        //public IActionResult GeiId(int id)
        //{
        //    return new JsonResult(adminService.GetById(id));
        //}

        //[HttpDelete]
        //public IActionResult Del(int id)
        //{
        //    return Ok(adminService.Delete(id));
        //}

        //[HttpPut]
        //public IActionResult Upd(AdminDto r)
        //{
        //    return Ok(adminService.Update(r));
        //}
    }
}
