using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlClientDB
{
    public enum roomTypes { single, @double, luxury};
    class Room
    {
        public int price { get; set; }
        public roomTypes roomType { get; set; }
    }
}
