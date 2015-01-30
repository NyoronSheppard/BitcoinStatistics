using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.NetworkInformation;
using System.Globalization;

namespace BitcoinStatistics.Models
{
    //Class to change Currency
    public class CurrencyConverter
    {
        //urlCurrency 
        public string urlCurrency { get; set; }

        //Currency Money Change
        public string moneyToResponse { get; set; }

        //Currency Name Change
        public string currencyToResponse { get; set; }

        //Constructor
        public CurrencyConverter(string currencyToResponse)
        {
            this.currencyToResponse = currencyToResponse;
            string urlCurrencyAux = "http://devel.farebookings.com/api/curconversor/" + App.ViewModel.Items[0].CurrencyApi + "/" + currencyToResponse + "/1/json";

            this.urlCurrency = @urlCurrencyAux; 

            WebClient webClientCurrency = new WebClient();
            webClientCurrency.Headers["Accept"] = "application/json";
            webClientCurrency.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompletedCurrency);
            webClientCurrency.DownloadStringAsync(new Uri(urlCurrency));

         }

        //Download CurrencyConvert
        private void webClient_DownloadCatalogCompletedCurrency(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {

                if (e.Result != null)
                {

                    switch (currencyToResponse)
                    {
                        case "USD":
                            var currencyUSD = JsonConvert.DeserializeObject<USDC>(e.Result);

                            //1 to X
                            moneyToResponse = currencyUSD.USD;
                            break;

                        case "EUR":
                            var currencyEUR = JsonConvert.DeserializeObject<EURC>(e.Result);

                            moneyToResponse = currencyEUR.EUR;
                            break;

                        case "GBP":
                            var currencyGBP = JsonConvert.DeserializeObject<GBPC>(e.Result);

                            moneyToResponse = currencyGBP.GBP;
                            break;

                        case "CAD":
                            var currencyCAD = JsonConvert.DeserializeObject<CADC>(e.Result);

                            moneyToResponse = currencyCAD.CAD;
                            break;

                        case "BRL":
                            var currencyBRL = JsonConvert.DeserializeObject<BRLC>(e.Result);

                            moneyToResponse = currencyBRL.BRL;
                            break;

                        case "CNY":
                            var currencyCNY = JsonConvert.DeserializeObject<CNYC>(e.Result);

                            moneyToResponse = currencyCNY.CNY;
                            break;

                        case "HKD":
                            var currencyHKD = JsonConvert.DeserializeObject<HKDC>(e.Result);

                            moneyToResponse = currencyHKD.HKD;
                            break;

                        case "JPY":
                            var currencyJPY = JsonConvert.DeserializeObject<JPYC>(e.Result);

                            moneyToResponse = currencyJPY.JPY;
                            break;

                        case "MXN":
                            var currencyMXN = JsonConvert.DeserializeObject<MXNC>(e.Result);

                            moneyToResponse = currencyMXN.MXN;
                            break;

                        case "NZD":
                            var currencyNZD = JsonConvert.DeserializeObject<NZDC>(e.Result);

                            moneyToResponse = currencyNZD.NZD;
                            break;

                        case "NOK":
                            var currencyNOK = JsonConvert.DeserializeObject<NOKC>(e.Result);

                            moneyToResponse = currencyNOK.NOK;
                            break;

                        case "RUB":
                            var currencyRUB = JsonConvert.DeserializeObject<RUBC>(e.Result);

                            moneyToResponse = currencyRUB.RUB;
                            break;

                        case "SEK":
                            var currencySEK = JsonConvert.DeserializeObject<SEKC>(e.Result);

                            moneyToResponse = currencySEK.SEK;
                            break;
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        App.ViewModel.Items[i].LastValue = ((float.Parse(App.ViewModel.Items[i].LastValue, CultureInfo.InvariantCulture.NumberFormat) * float.Parse(moneyToResponse, CultureInfo.InvariantCulture.NumberFormat))).ToString("0.00").Replace(',', '.');


                        if (App.ViewModel.Items[i].HighValue != "")
                        {
                            App.ViewModel.Items[i].LowValue = ((float.Parse(App.ViewModel.Items[i].LowValue, CultureInfo.InvariantCulture.NumberFormat) * float.Parse(moneyToResponse, CultureInfo.InvariantCulture.NumberFormat))).ToString("0.00").Replace(',', '.');
                            App.ViewModel.Items[i].HighValue = ((float.Parse(App.ViewModel.Items[i].HighValue, CultureInfo.InvariantCulture.NumberFormat) * float.Parse(moneyToResponse, CultureInfo.InvariantCulture.NumberFormat))).ToString("0.00").Replace(',', '.');
                        }

                        App.ViewModel.Items[i].CurrencyApi = currencyToResponse;
                    }
                }
            }
            catch //(Exception ex)
            {

            }
        }
    }

    //GBP Currency
    public class GBPC
    {
        public string GBP { get; set; }
    }

    //EUR Currency
    public class EURC
    {
        public string EUR { get; set; }
    }

    //USD Currency
    public class USDC
    {
        public string USD { get; set; }
    }

    //BRL Currency
    public class BRLC
    {
        public string BRL { get; set; }
    }

    //CAD Currency
    public class CADC
    {
        public string CAD { get; set; }
    }

    //CNY Currency
    public class CNYC
    {
        public string CNY { get; set; }
    }

    //HKD Currency
    public class HKDC
    {
        public string HKD { get; set; }
    }

    //JPY Currency
    public class JPYC
    {
        public string JPY { get; set; }
    }

    //MXN Currency
    public class MXNC
    {
        public string MXN { get; set; }
    }

    //NZD Currency
    public class NZDC
    {
        public string NZD { get; set; }
    }

    //NOK Currency
    public class NOKC
    {
        public string NOK { get; set; }
    }

    //RUB Currency
    public class RUBC
    {
        public string RUB { get; set; }
    }

    //SEK Currency
    public class SEKC
    {
        public string SEK { get; set; }
    }
}
