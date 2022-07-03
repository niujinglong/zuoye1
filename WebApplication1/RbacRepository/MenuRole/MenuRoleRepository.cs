using ClassLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacRepository.MenuRole
{
    public class MenuRoleRepository : BaseDTO<Rbac.Entity.MenuRole, int>, IMenuRoleRepository
    {
        public MenuRoleRepository(MyDbContext dbContext)
        {
            this.db = dbContext;
        }
    }
}
