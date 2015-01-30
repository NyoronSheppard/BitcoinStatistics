using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BitcoinStatistics.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        //API Identifier
        private string _id;
        
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        //API Name
        private string nameApi;

        public string NameApi
        {
            get
            {
                return nameApi;
            }
            set
            {
                if (value != nameApi)
                {
                    nameApi = value;
                    NotifyPropertyChanged("NameApi");
                }
            }
        }

        //Last Value
        private string _lastValue;

        public string LastValue
        {
            get
            {
                return _lastValue;
            }
            set
            {
                if (value != _lastValue)
                {
                    _lastValue = value;
                    NotifyPropertyChanged("LastValue");
                }
            }
        }

        //Difference between last and last old value
        private string _difference;

        public string Difference
        {
            get
            {
                return _difference;
            }
            set
            {
                if (value != _difference)
                {
                    _difference = value;
                    NotifyPropertyChanged("Difference");
                }
            }
        }

        //Difference color
        private string _differenceColor;

        public string DifferenceColor
        {
            get
            {
                return _differenceColor;
            }
            set
            {
                if (value != _differenceColor)
                {
                    _differenceColor = value;
                    NotifyPropertyChanged("DifferenceColor");
                }
            }
        }

        //Last Value USD
        private string _lastValueUSD;

        public string LastValueUSD
        {
            get
            {
                return _lastValueUSD;
            }
            set
            {
                if (value != _lastValueUSD)
                {
                    _lastValueUSD = value;
                    NotifyPropertyChanged("LastValueUSD");
                }
            }
        }

        //Low Value
        private string _lowValue;

        public string LowValue
        {
            get
            {
                return _lowValue;
            }
            set
            {
                if (value != _lowValue)
                {
                    _lowValue = value;
                    NotifyPropertyChanged("LowValue");
                }
            }
        }

        //High Value
        private string _highValue;

        public string HighValue
        {
            get
            {
                return _highValue;
            }
            set
            {
                if (value != _highValue)
                {
                    _highValue = value;
                    NotifyPropertyChanged("HighValue");
                }
            }
        }

        //API Country
        private string _countryApi;

        public string CountryApi
        {
            get
            {
                return _countryApi;
            }
            set
            {
                if (value != _countryApi)
                {
                    _countryApi= value;
                    NotifyPropertyChanged("CountryApi");
                }
            }
        }

        //API Currency
        private string _currencyApi;

        public string CurrencyApi
        {
            get
            {
                return _currencyApi;
            }
            set
            {
                if (value != _currencyApi)
                {
                    _currencyApi = value;
                    NotifyPropertyChanged("CurrencyApi");
                }
            }
        }

        //Last Update Api
        private string _lastUpdate;

        public string LastUpdate
        {
            get
            {
                return _lastUpdate;
            }
            set
            {
                if (value != _lastUpdate)
                {
                    _lastUpdate = value;
                    NotifyPropertyChanged("LastUpdate");
                }
            }
        }

        //Url Api
        private string _urlApi;

        public string UrlApi
        {
            get
            {
                return _urlApi;
            }
            set
            {
                if (value != _urlApi)
                {
                    _urlApi = value;
                    NotifyPropertyChanged("UrlApi");
                }
            }
        }

        //Arrow Source
        private string _arrowSource;

        public string ArrowSource
        {
            get
            {
                return _arrowSource;
            }
            set
            {
                if (value != _arrowSource)
                {
                    _arrowSource = value;
                    NotifyPropertyChanged("ArrowSource");
                }
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