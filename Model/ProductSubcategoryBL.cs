using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class ProductSubcategoryBL
    {
        [Key]
        public int ProductSubCategoryId { get; set; }
        public Nullable<int> ProductCategoryId { get; set; }
        public string ProductSubCategoryName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public bool IsNeedsToDelete { get; set; }

    }
}
