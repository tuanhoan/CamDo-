using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Utilities.Helper
{
    public class UIHelper
    {
        public static string GetAvatar(string avatar)
        {
            if (string.IsNullOrEmpty(avatar))
            {
                avatar = "/images/avatar/avatar.jpg";
            }
            return avatar;
        }
    }
}
