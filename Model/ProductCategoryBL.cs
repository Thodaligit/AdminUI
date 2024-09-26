using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class ProductCategoryBL
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public Nullable<int> MasterProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }                
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }      
        public bool IsNeedsToDelete { get; set; }
    }
}