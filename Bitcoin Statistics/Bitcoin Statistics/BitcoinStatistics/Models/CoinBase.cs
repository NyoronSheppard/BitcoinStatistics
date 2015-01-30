using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinStatistics.Models
{
    //Bitcoin Bitstamp Statistics Class
    public class CoinBase
    {
        public Subtotal subtotal { get; set; }
        public List<Fee> fees { get; set; } 
        public string amount { get; set; }
        public string currency { get; set; } //USD, EUR, ...
    }
    
    //Price without Bank taxes
    public class Subtotal
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    //Fee Subclass (Currency / 100)
    public class Coinbase
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    //Bank Taxes
    public class Bank
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    //Fee class
    public class Fee
    {
        public Coinbase coinbase { get; set; }
        public Bank bank { get; set; }
    }

    //Subtotal + Bank
    public class Total
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }
}
