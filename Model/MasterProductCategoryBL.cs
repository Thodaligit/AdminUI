using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class MasterProductCategoryBL
    {
        [Key]
        public int MasterProductCategoryId { get; set; }
        public string MasterProductCategoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }      
        public bool IsNeedsToDelete { get; set; }
    }
}