using System;
using System.Collections.Generic;
using System.Text;

namespace LocationStatus.DataPack
{
    public class Temperature
    {
		public double temp { get; set; }
		public int pressure { get; set; }
		public int humidity { get; set; }
		public double temp_min { get; set; }
		public double temp_max { get; set; }
	}
}
