using System.Collections.Generic;

namespace AdminUI.Models
{
    public class ProductCategoryBLVM
    {
        public ProductCategoryBLVM()
        {
            ProductCategories = new List<ProductCategoryBL>();
        }
        public List<ProductCategoryBL> ProductCategories { get; set; }
    }
}