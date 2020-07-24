using System;
using System.Collections.Generic;
using System.Text;

namespace ioliu.domain
{
   public class System_Page_action
    {
        public int id { get; set; }
        public DateTime DataChangeLastTime
        {
            get
            {
                return _DataChangeLastTime;
            }
            set
            {
                _DataChangeLastTime = value;
            }
        }
        public int MenuID { get; set; }
        public string ActionId { get; set; }
        public string ActionName { get; set; }
        public string ControlName { get; set; }


        private DateTime _DataChangeLastTime = DateTime.Now;
    }
}
