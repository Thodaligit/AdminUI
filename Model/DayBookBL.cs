using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class DayBookBL
    {
        [Key]
        public int DayBookId { get; set; }
        public int OrderId { get; set; }
        public string AccountName { get; set; }
        public System.DateTime AccountDate { get; set; }
        public string Description { get; set; }
        public Decimal OpeningBalance { get; set; }
        public Decimal DueAmount { get; set; }
        public Decimal ImpactAmount { get; set; }
        public Decimal NonImpactAmount { get; set; }
        public Decimal ClosingBalance { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }      
        public bool IsNeedsToDelete { get; set; }
    }
}