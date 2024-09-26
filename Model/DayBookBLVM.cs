using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class DayBookBLVM
    {
        public DayBookBLVM()
        {
            ObjDayBookBLList = new List<DayBookBL>();
        }
        public List<DayBookBL> ObjDayBookBLList { get; set; }
    }
}