using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.User
{
    public class RoleTree
    {
        public int FuncId { get; set; }
        public string DisplayName { get; set; }
        public int Level { get; set; }
        public int SubId { get; set; }
        public List<RoleTree> RoleUsers { get; set; }
    }

    public class DataLoadTreeRoleFunc
    {
        public List<RoleTree> RoleUsers { get; set; }
        public List<int>FuncAuthByUser { get; set; }
    }

    public class ModelSaveFuncRole
    {
        public List<int> ListFunc { get; set; }
        public string UserId { get; set; }
    }
    public class SetRoleForUserModel
    {
        public string userId { get; set; }
        public string FuncId { get; set; }
        public bool check { get; set; }
    }
}
