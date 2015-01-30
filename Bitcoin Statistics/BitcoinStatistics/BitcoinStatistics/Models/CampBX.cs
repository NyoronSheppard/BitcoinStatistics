using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinStatistics.Models
{
    //Bitcoin CampBX Statistics Class
    class CampBX
    {
        public string Trade { get; set; }
        public string  Bid { get; set; } //Best Offer
        public string  Ask { get; set; } //Best Demand
    }
}
