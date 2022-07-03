using Rbac.Entity;
using System;
using System.Collections.Generic;

namespace RbacApplication
{
    public interface Iapplication
    {
        List<MenuDto> GetAll();
        List<MenuCrealist> GetList();
        int Add(Rbac.Entity.Menu menu);
        int Del(Rbac.Entity.Menu menu);
        int Edit(Rbac.Entity.Menu menu);
        List<Rbac.Entity.Menu> Show();
    }
}
