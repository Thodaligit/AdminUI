using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class OrderDetailBLVM
    {
        public OrderDetailBLVM()
        {
            ObjOrderDetailBLList = new List<OrderDetailBL>();
        }
        public List<OrderDetailBL> ObjOrderDetailBLList { get; set; }
    }
}