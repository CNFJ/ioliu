using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ioliu.domain
{
    public class System_Menu
    {
        [Required]
        public int id { get; set; }
        [Required]
       
        public DateTime DataChangeLastTime {
            get
            {
                return _DataChangeLastTime;
            }
            set
            {
                _DataChangeLastTime = value;
            }
        }
        public Boolean IsActive { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Ico { get; set; }
        public string Url { get; set; }
        public int OrderRule { get; set; }
        public int Level { get; set; }
        public int Class { get; set; }
        private DateTime _DataChangeLastTime = DateTime.Now;
    }
}
