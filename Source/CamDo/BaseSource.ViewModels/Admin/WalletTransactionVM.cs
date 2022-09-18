﻿using BaseSource.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Admin
{
    public class WalletTransactionVM
    {
        public string NameUser { get; set; }
        public string TargetType { get; set; }
        public int SoBaoHiem { get; set; }
        public double Sotien { get; set; }
        public string NhanVienGiaoDich { get; set; }
        public DateTime NgayGiaoDich { get; set; }
    }

    public class WalletTransactionPagingRequest_Admin : PageQuery
    {
        public string Info { get; set; }
    }
}
