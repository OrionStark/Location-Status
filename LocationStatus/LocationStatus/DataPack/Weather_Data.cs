using System;
using System.Collections.Generic;
using System.Text;

namespace LocationStatus.DataPack
{
    public class Weather_Data
    {
		public List<W_Description> weather { set; get; }
		public Temperature main { set; get; }
		public Wind wind { set; get; }
    }
}
