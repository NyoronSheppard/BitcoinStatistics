using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinStatistics.Models
{
    //Bitcoin MtGox Statistics Class
    public class BitcoinMtGox
    {
        public string result { get; set; }
        public Return @return { get; set; }
    }

    //Return values MtGox
    public class Return
    {
        public High high { get; set; }
        public Low low { get; set; }
        public Avg avg { get; set; }
        public Vwap vwap { get; set; }
        public Vol vol { get; set; }
        public LastLocal last_local { get; set; }
        public LastOrig last_orig { get; set; }
        public LastAll last_all { get; set; }
        public Last last { get; set; }
        public Buy buy { get; set; }
        public Sell sell { get; set; }
        public string item { get; set; }
        public string now { get; set; }
    }

    //Bitcoin high value
    public class High
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; } //Visualización

        public string display_short { get; set; }
        public string currency { get; set; } //Moneda
    }

    //Bitcoin low value
    public class Low
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; }
        public string display_short { get; set; }
        public string currency { get; set; }
    }

    //Bitcoin average value (promedio)
    public class Avg
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; }
        public string display_short { get; set; }
        public string currency { get; set; }
    }

    //Bitcoin volume weighted average price (radio del volumen tradeado)
    public class Vwap
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; }
        public string display_short { get; set; }
        public string currency { get; set; }
    }

    //Bitcoin volume
    public class Vol
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; }
        public string display_short { get; set; }
        public string currency { get; set; }
    }

    //Bitcoin last local (the last trade in the selected currency)
    public class LastLocal
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; }
        public string display_short { get; set; }
        public string currency { get; set; }
    }

    //Bitcoin last origin (include data of the original last trade)
    public class LastOrig
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; }
        public string display_short { get; set; }
        public string currency { get; set; }
    }

    //Bitcoin last all (the last trade in ANY currency, converted to your currency)
    public class LastAll
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; }
        public string display_short { get; set; }
        public string currency { get; set; }
    }

    //Bitcoin last trade
    public class Last
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; }
        public string display_short { get; set; }
        public string currency { get; set; }
    }

    //Bitcoin buy
    public class Buy
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; }
        public string display_short { get; set; }
        public string currency { get; set; }
    }

    //Bitcoin Sell
    public class Sell
    {
        public string value { get; set; }
        public string value_int { get; set; }
        public string display { get; set; }
        public string display_short { get; set; }
        public string currency { get; set; }
    }
}
