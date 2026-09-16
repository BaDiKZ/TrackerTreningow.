using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerTreningow_
{
    public class Badge
    {
        public string Code { get; set; } = "";

        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime EarnedAt { get; set; }
    }
}
