using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Core.Entities
{
    public partial class SysError
    {
        public int ID { get; set; }
        public DateTime? ERR_DATE { get; set; }
        public string ERR_TIME { get; set; }
        public string ERR_MSG { get; set; }
        public string PRG_CODE { get; set; }
    }
}
