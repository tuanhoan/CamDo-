using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Shared.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "BaseSourceDbConnection";
        public const string SiteAuthorName = "Online Store";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BackendApiClient = "BackendApiClient";
        }
        public static class TrangThai
        {
            public static List<object> ListTrangThai()
            {
                var lstStatus = new List<object>();
                lstStatus.Add(new { value = 1, text = "Hoạt động" });
                lstStatus.Add(new { value = 0, text = "Tạm dừng" });
                return lstStatus;
            }
        }
    }

}

