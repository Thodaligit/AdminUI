using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class ProductBLVM
    {
        public ProductBLVM()
        {
            ObjProductBLList = new List<ProductBL>();
        }
        public List<ProductBL> ObjProductBLList { get; set; }
    }
}