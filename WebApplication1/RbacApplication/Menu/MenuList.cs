using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication.Menu
{
    public class MenuList
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string LinkUrl { get; set; }
        public int ParentId { get; set; }
        public bool IsShow { get; set; }
    }
}
