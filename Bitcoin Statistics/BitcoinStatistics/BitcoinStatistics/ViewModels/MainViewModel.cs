using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using Newtonsoft.Json;
using BitcoinStatistics.Resources;
using BitcoinStatistics.Models;
using System.Globalization;

namespace BitcoinStatistics.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //MtGox Url Api
        const string urlMtGox = @"http://data.mtgox.com/api/1/BTCUSD/ticker";

        //Btc-e Url Api
        const string urlBtcE = @"https://btc-e.com/api/2/1/ticker";

        //Bitstamp Url Api
        const string urlBitstamp = @"https://www.bitstamp.net/api/ticker";

        //CoinBase Url Api
        const string urlCoinBase = @"https://coinbase.com/api/v1/prices/buy";

        //CampBX Url Api
        //const string urlCampBX = @"http://campbx.com/api/xticker.php";

        //LocalBitCoins Url Api
        const string urlLocalbitcoins = @"https://localbitcoins.com/bitcoinaverage/ticker-all-currencies/";

        //Api ID
        private int id = 0;

        //Constructor
        public MainViewModel()
        {
            //First Call to DataBase
            DataB = new DataBaseContext("Data Source=isostore:/DB.sdf");

            this.Items = new ObservableCollection<ItemViewModel>();
        }

        //DataBase
        public DataBaseContext DataB { get; set; }

        //Collection for ItemViewModel objects
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<ItemViewModel> CopyItems { get; private set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        //Create and adds a few ItemViewModel objects into the Items collection
        public void LoadData()
        {
            //Create DataBase 
            DataB = new DataBaseContext("Data Source=isostore:/DB.sdf");

            using (DataB)
            {
                if (!DataB.DatabaseExists())
                {
                    DataB.CreateDatabase();
                    DataB.SubmitChanges();
                }
                else
                {
                    int last = 0;
                    foreach(var item in DataB.Tile)
                    {
                        if(last <= item.TileUpdateId)
                        {
                            last = item.TileUpdateId;

                            TileUpdate.idTile = item.TileUpdateId;
                            TileUpdate.modelTile = item.ModelTile;
                            TileUpdate.currencyTile = item.CurrencyTile;
                            TileUpdate.seeTile = item.SeeTile;
                            TileUpdate.updateTile = item.UpdateTile;
                            TileUpdate.valueTile = item.ValueTile;

                            DataB.SubmitChanges();
                        }
                    }
                }
            }

            //if (this.IsDataLoaded == false)
            //{

                this.Items.Clear();
                id = 0;

                //this.Items.Add(new ItemViewModel() { ID = "0", LineOne = "Please Wait...", LineTwo = "Please wait while the catalog is downloaded from the server.", LineThree = null });

                //Load Web Api

                WebClient webClientMtGox = new WebClient();
                webClientMtGox.Headers["Accept"] = "application/json";
                webClientMtGox.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompletedMtGox);
                webClientMtGox.DownloadStringAsync(new Uri(urlMtGox));

                WebClient webClientBtcE = new WebClient();
                webClientBtcE.Headers["Accept"] = "application/json";
                webClientBtcE.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompletedBtcE);
                webClientBtcE.DownloadStringAsync(new Uri(urlBtcE));

                WebClient webClientBitstamp = new WebClient();
                webClientBitstamp.Headers["Accept"] = "application/json";
                webClientBitstamp.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompletedBitstamp);
                webClientBitstamp.DownloadStringAsync(new Uri(urlBitstamp));

                WebClient webClientCoinBase = new WebClient();
                webClientCoinBase.Headers["Accept"] = "application/json";
                webClientCoinBase.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompletedCoinBase);
                webClientCoinBase.DownloadStringAsync(new Uri(urlCoinBase));

                //WebClient webClientCampBX = new WebClient();
                //webClientCampBX.Headers["Accept"] = "application/json";
                //webClientCampBX.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompletedCampBX);
                //webClientCampBX.DownloadStringAsync(new Uri(urlCampBX));  

                WebClient webClientLocalbitcoins = new WebClient();
                webClientLocalbitcoins.Headers["Accept"] = "application/json";
                webClientLocalbitcoins.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompletedLocalbitcoins);
                webClientLocalbitcoins.DownloadStringAsync(new Uri(urlLocalbitcoins));
            //}

            //IsDataLoaded = false;
        }

        //Download MtGox
        private void webClient_DownloadCatalogCompletedMtGox(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            { 
                //this.Items.Clear();

                if (e.Result != null)
                {
                    var mtGox = JsonConvert.DeserializeObject<BitcoinMtGox>(e.Result);
                    
                    this.Items.Insert(0, new ItemViewModel()
                    {
                        ID = (id++).ToString(),
                        NameApi = "MtGox",
                        LastValue = float.Parse(mtGox.@return.last.value, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',','.'),
                        LowValue = float.Parse(mtGox.@return.low.value, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',', '.'),
                        HighValue = float.Parse(mtGox.@return.high.value, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',', '.'),
                        CountryApi = "Japan",
                        CurrencyApi = "USD",
                        LastUpdate = DateTime.Now.ToString(),
                        ArrowSource = "",
                        LastValueUSD = float.Parse(mtGox.@return.last.value, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',', '.')
                    });

                    this.IsDataLoaded = true;
                }
            }
            catch //(Exception ex)
            {
                this.Items.Add(new ItemViewModel()
                {
                    ID = "0",
                    NameApi = "An Error Occurred",
                    //LineTwo = String.Format("The following exception occured: {0}", ex.Message),
                    //LineThree = String.Format("Additional inner exception information: {0}", ex.InnerException.Message)
                });
            }
        }

        //Download Btc-e
        private void webClient_DownloadCatalogCompletedBtcE(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    var btcE = JsonConvert.DeserializeObject<BitcoinBtcE>(e.Result);

                    this.Items.Add(new ItemViewModel()
                    {
                        ID = (id++).ToString(),
                        NameApi = "Btc-e",
                        LastValue = btcE.ticker.last.ToString("0.00").Replace(',', '.'),
                        LowValue = btcE.ticker.low.ToString("0.00").Replace(',', '.'),
                        HighValue = btcE.ticker.high.ToString("0.00").Replace(',', '.'),
                        CountryApi = "Russia",
                        CurrencyApi = "USD",
                        LastUpdate = DateTime.Now.ToString(),
                        LastValueUSD = btcE.ticker.last.ToString("0.00").Replace(',', '.')
                    });

                    this.IsDataLoaded = true;
                }
            }
            catch //(Exception ex)
            {
                this.Items.Add(new ItemViewModel()
                {
                    ID = "0",
                    NameApi = "An Error Occurred",
                    //LineTwo = String.Format("The following exception occured: {0}", ex.Message),
                    //LineThree = String.Format("Additional inner exception information: {0}", ex.InnerException.Message)
                });
            }
        }

        //Download Bitstamp
        private void webClient_DownloadCatalogCompletedBitstamp(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    var bitstamp = JsonConvert.DeserializeObject<Bitstamp>(e.Result);

                    this.Items.Add(new ItemViewModel()
                    {
                        ID = (id++).ToString(),
                        NameApi = "Bitstamp",
                        LastValue = float.Parse(bitstamp.last, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',', '.'),
                        LowValue = float.Parse(bitstamp.low, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',', '.'),
                        HighValue = float.Parse(bitstamp.high, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',', '.'),
                        CountryApi = "Slovenia",
                        CurrencyApi = "USD",
                        LastUpdate = DateTime.Now.ToString(),
                        LastValueUSD = float.Parse(bitstamp.last, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',', '.')
                    });

                    this.IsDataLoaded = true;
                }
            }
            catch //(Exception ex)
            {
                this.Items.Add(new ItemViewModel()
                {
                    ID = "0",
                    NameApi = "An Error Occurred",
                    //LineTwo = String.Format("The following exception occured: {0}", ex.Message),
                    //LineThree = String.Format("Additional inner exception information: {0}", ex.InnerException.Message)
                });
            }
        }

        //Download CoinBase
        private void webClient_DownloadCatalogCompletedCoinBase(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {

                if (e.Result != null)
                {
                    var coinBase = JsonConvert.DeserializeObject<CoinBase>(e.Result);

                    this.Items.Add(new ItemViewModel()
                    {
                        ID = (id++).ToString(),
                        NameApi = "CoinBase",
                        LastValue = float.Parse(coinBase.amount, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',', '.'),
                        LowValue = "",
                        HighValue = "",
                        CountryApi = "United States",
                        CurrencyApi = "USD",
                        LastUpdate = DateTime.Now.ToString(),
                        LastValueUSD = float.Parse(coinBase.amount, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',', '.')
                    });

                    this.IsDataLoaded = true;
                }
            }
            catch //(Exception ex)
            {
                this.Items.Add(new ItemViewModel()
                {
                    ID = "0",
                    NameApi = "An Error Occurred",
                    //LineTwo = String.Format("The following exception occured: {0}", ex.Message),
                    //LineThree = String.Format("Additional inner exception information: {0}", ex.InnerException.Message)
                });
            }
        }

        //Download CampBX
       /* private void webClient_DownloadCatalogCompletedCampBX(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                //this.Items.Clear();

                if (e.Result != null)
                {
                    var campBX = JsonConvert.DeserializeObject<CampBX>(e.Result);
                    //int id = 0;

                    this.Items.Add(new ItemViewModel()
                    {
                        ID = (id++).ToString(),
                        LineOne = "CampBX",
                        LineTwo = float.Parse(campBX.Trade, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00"),
                        LineThree = float.Parse(campBX.Ask, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00"),
                        LineFour = float.Parse(campBX.Bid, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00")
                    });

                    this.IsDataLoaded = true;
                }
            }
            catch //(Exception ex)
            {
                this.Items.Add(new ItemViewModel()
                {
                    ID = "0",
                    LineOne = "An Error Occurred",
                    //LineTwo = String.Format("The following exception occured: {0}", ex.Message),
                    //LineThree = String.Format("Additional inner exception information: {0}", ex.InnerException.Message)
                });
            }
        }*/

        //Download Localbitcoins
        private void webClient_DownloadCatalogCompletedLocalbitcoins(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {

                if (e.Result != null)
                {
                    var localbitcoins = JsonConvert.DeserializeObject<Localbitcoins>(e.Result);

                    this.Items.Add(new ItemViewModel()
                    {
                        ID = (id++).ToString(),
                        NameApi = "LocalBitcoins",
                        LastValue = float.Parse(localbitcoins.USD.rates.last, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',', '.'),
                        LowValue = "",
                        HighValue = "",
                        CountryApi = "Finland",
                        CurrencyApi = "USD",
                        LastUpdate = DateTime.Now.ToString(),
                        LastValueUSD = float.Parse(localbitcoins.USD.rates.last, CultureInfo.InvariantCulture.NumberFormat).ToString("0.00").Replace(',', '.')
                    });

                    this.IsDataLoaded = true;
                }
            }
            catch //(Exception ex)
            {
                this.Items.Add(new ItemViewModel()
                {
                    ID = "0",
                    NameApi = "An Error Occurred",
                    //LineTwo = String.Format("The following exception occured: {0}", ex.Message),
                    //LineThree = String.Format("Additional inner exception information: {0}", ex.InnerException.Message)
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}