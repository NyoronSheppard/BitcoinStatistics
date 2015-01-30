using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinStatistics.Models
{
    //All currency
    public class Localbitcoins
    {
        public USD USD { get; set; }
    }

    //USD Rate
    public class Rates
    {
        public string last { get; set; }
    }

    //USD Currency
    public class USD
    {
        public double avg_1h { get; set; }
        public Rates rates { get; set; }
        public double avg_12h { get; set; }
        public string volume_btc { get; set; }
        public double avg_3h { get; set; }
        public double avg_24h { get; set; }
    }

//    //GBP Rate
//    public class Rates2
//    {
//        public string last { get; set; }
//    }

//    //GBP Currency
//    public class GBP
//    {
//        public double avg_1h { get; set; }
//        public Rates2 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //AUD Rate
//    public class Rates3
//    {
//        public string last { get; set; }
//    }

//    //AUD Currency
//    public class AUD
//    {
//        public object avg_1h { get; set; }
//        public Rates3 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //EUR Rate
//    public class Rates4
//    {
//        public string last { get; set; }
//    }

//    //EUR Currency
//    public class EUR
//    {
//        public double avg_1h { get; set; }
//        public Rates4 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //CZK Rate
//    public class Rates5
//    {
//        public string last { get; set; }
//    }

//    //CZK Currency
//    public class CZK
//    {
//        public object avg_1h { get; set; }
//        public Rates5 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //COP Rate
//    public class Rates6
//    {
//        public string last { get; set; }
//    }

//    //COP Currency
//    public class COP
//    {
//        public object avg_1h { get; set; }
//        public Rates6 rates { get; set; }
//        public object avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //NZD Rate
//    public class Rates7
//    {
//        public string last { get; set; }
//    }

//    //NZD Currency
//    public class NZD
//    {
//        public double avg_1h { get; set; }
//        public Rates7 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //CAD Rate
//    public class Rates8
//    {
//        public string last { get; set; }
//    }

//    //CAD Currency
//    public class CAD
//    {
//        public double avg_1h { get; set; }
//        public Rates8 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //MXN Rate
//    public class Rates9
//    {
//        public string last { get; set; }
//    }

//    //MXN Currency
//    public class MXN
//    {
//        public double avg_1h { get; set; }
//        public Rates9 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }
    
//    //BRL Rate
//    public class Rates10
//    {
//        public string last { get; set; }
//    }

//    //BRL Currency
//    public class BRL
//    {
//        public object avg_1h { get; set; }
//        public Rates10 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //HKD Rate
//    public class Rates11
//    {
//        public string last { get; set; }
//    }

//    //HKD Currency
//    public class HKD
//    {
//        public object avg_1h { get; set; }
//        public Rates11 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //ZAR Rate
//    public class Rates12
//    {
//        public string last { get; set; }
//    }

//    //ZAR Currency
//    public class ZAR
//    {
//        public object avg_1h { get; set; }
//        public Rates12 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //THB Rate
//    public class Rates13
//    {
//        public string last { get; set; }
//    }

//    //THB Currency
//    public class THB
//    {
//        public object avg_1h { get; set; }
//        public Rates13 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //PHP Rate
//    public class Rates14
//    {
//        public string last { get; set; }
//    }

//    //PHP Currency
//    public class PHP
//    {
//        public object avg_1h { get; set; }
//        public Rates14 rates { get; set; }
//        public object avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //KRW Rate
//    public class Rates15
//    {
//        public string last { get; set; }
//    }

//    //KRW Currency
//    public class KRW
//    {
//        public object avg_1h { get; set; }
//        public Rates15 rates { get; set; }
//        public object avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //CNY Rate
//    public class Rates16
//    {
//        public string last { get; set; }
//    }

//    //CNY Currency
//    public class CNY
//    {
//        public object avg_1h { get; set; }
//        public Rates16 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //INR Rate
//    public class Rates17
//    {
//        public string last { get; set; }
//    }

//    //INR Currency
//    public class INR
//    {
//        public object avg_1h { get; set; }
//        public Rates17 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //CHF Rate
//    public class Rates18
//    {
//        public string last { get; set; }
//    }

//    //CHF Currency
//    public class CHF
//    {
//        public object avg_1h { get; set; }
//        public Rates18 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //NOK Rate
//    public class Rates19
//    {
//        public string last { get; set; }
//    }

//    //NOK Currency
//    public class NOK
//    {
//        public object avg_1h { get; set; }
//        public Rates19 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //RON Rate
//    public class Rates20
//    {
//        public string last { get; set; }
//    }

//    //RON Currency
//    public class RON
//    {
//        public object avg_1h { get; set; }
//        public Rates20 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //HUF Rate
//    public class Rates21
//    {
//        public string last { get; set; }
//    }

//    //HUF Currency
//    public class HUF
//    {
//        public object avg_1h { get; set; }
//        public Rates21 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //SGD Rate
//    public class Rates22
//    {
//        public string last { get; set; }
//    }

//    //SGD Currency
//    public class SGD
//    {
//        public object avg_1h { get; set; }
//        public Rates22 rates { get; set; }
//        public object avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //SEK Rate
//    public class Rates23
//    {
//        public string last { get; set; }
//    }

//    //SEK Currency
//    public class SEK
//    {
//        public object avg_1h { get; set; }
//        public Rates23 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //IDR Rate
//    public class Rates24
//    {
//        public string last { get; set; }
//    }

//    //IDR Currency
//    public class IDR
//    {
//        public object avg_1h { get; set; }
//        public Rates24 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //ARS Rate 
//    public class Rates25
//    {
//        public string last { get; set; }
//    }

//    //ARS Currency
//    public class ARS
//    {
//        public double avg_1h { get; set; }
//        public Rates25 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //PLN Rate
//    public class Rates26
//    {
//        public string last { get; set; }
//    }

//    //PLN Currency
//    public class PLN
//    {
//        public object avg_1h { get; set; }
//        public Rates26 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //RUB Rate
//    public class Rates27
//    {
//        public string last { get; set; }
//    }

//    //RUB Currency
//    public class RUB
//    {
//        public double avg_1h { get; set; }
//        public Rates27 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //LTL Rate
//    public class Rates28
//    {
//        public string last { get; set; }
//    }

//    //LTL Currency
//    public class LTL
//    {
//        public object avg_1h { get; set; }
//        public Rates28 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //JPY Rate
//    public class Rates29
//    {
//        public string last { get; set; }
//    }

//    //JPY Currency
//    public class JPY
//    {
//        public object avg_1h { get; set; }
//        public Rates29 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //MAD Rate
//    public class Rates30
//    {
//        public string last { get; set; }
//    }

//    //MAD Currency
//    public class MAD
//    {
//        public object avg_1h { get; set; }
//        public Rates30 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public object avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }

//    //CLP Rate
//    public class Rates31
//    {
//        public string last { get; set; }
//    }

//    //CLP Currency
//    public class CLP
//    {
//        public double avg_1h { get; set; }
//        public Rates31 rates { get; set; }
//        public double avg_12h { get; set; }
//        public string volume_btc { get; set; }
//        public double avg_3h { get; set; }
//        public double avg_24h { get; set; }
//    }
}
