using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinStatistics.Models
{
    //Update the last value from DataBase
    public static class ValueUpdate
    {
        //Value MtGox
        public static string valueMtGox;

        //Value Btc-e
        public static string valueBtce;

        //Value Bitstamp
        public static string valueBitstamp;

        //Value CampBX
        public static string valueCampBX;

        //Value LocalBitcoins
        public static string valueLocalBitcoins;

        //Value CoinBase
        public static string valueCoinBase;


        //Symbol
        public static string symbol;

        //Update value list from DataBase
        public static void updateLastValue(string value, string symbol)
        {
            if(symbol == "MtGox")
            {
                valueMtGox = value;
            }
            else if(symbol == "Btc-e")
            {
                valueBtce = value;
            }
            else if(symbol == "Bitstamp")
            {
                valueBitstamp = value;
            }
            else if(symbol == "CoinBase")
            {
                valueCoinBase = value;
            }
            else if(symbol == "LocalBitcoins")
            {
                valueLocalBitcoins = value;
            }
        }

        //Get one last value
        public static string getLastValue(string symbol)
        {
            string lastValue = "";

            if (symbol == "MtGox")
            {
                lastValue = valueMtGox;
            }
            else if (symbol == "Btc-e")
            {
                lastValue = valueBtce;
            }
            else if (symbol == "Bitstamp")
            {
                lastValue = valueBitstamp;
            }
            else if (symbol == "CoinBase")
            {
                lastValue = valueCoinBase;
            }
            else if (symbol == "LocalBitcoins")
            {
                lastValue = valueLocalBitcoins;
            }

            return lastValue;
        }
    }
}
