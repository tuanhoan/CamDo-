using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class WalletTransaction
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }
        public byte TargetType { get; set; }
        public int TargetId { get; set; }
        public double Amount { get; set; }
        public double BalanceBefore { get; set; }
        public double BalanceAffter { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
