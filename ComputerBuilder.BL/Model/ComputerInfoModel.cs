using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuilder.BL.Model
{
    public class ComputerInfoModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> HardwareItemIds { get; set; }
    }
}
