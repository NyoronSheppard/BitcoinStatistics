using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinStatistics.Models
{
    //Bitcoin BitcoinBtcE Statistics Class
    public class BitcoinBtcE
    {
        public Ticker ticker { get; set; }
    }

    //Ticker class for last trade
    public class Ticker
    {
        public double high { get; set; }
        public double low { get; set; }
        public double avg { get; set; }
        public double vol { get; set; }
        public double vol_cur { get; set; }
        public double last { get; set; }
        public double buy { get; set; }
        public double sell { get; set; }
        public int updated { get; set; }
        public int server_time { get; set; }
    }
}
