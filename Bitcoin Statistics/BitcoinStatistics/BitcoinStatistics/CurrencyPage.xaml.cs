using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BitcoinStatistics.Models;
using System.Windows.Media;

namespace BitcoinStatistics
{
    public partial class CurrencyPage : PhoneApplicationPage
    {
        private static bool isCreated = false;
        public CurrencyPage()
        {
            InitializeComponent();
            
            if(isCreated == false)
            {
                CurrencyBoxList.ItemsSource = CurrencyList.GetCurrencyStart();
                isCreated = true;
            }  
            else
            {
                CurrencyBoxList.ItemsSource = CurrencyList.GetCurrency();
            }

            ////Change text to red
            //foreach(var value in CurrencyList.currencys)
            //{
            //    if(value.selected == true)
            //    {

            //    }
            //}
        }

        //Currency Class
        public class Currency
        {
            public string ID { get; set; }
            public string nameCurrency { get; set; }
            public bool selected { get; set; }
        }

        //Create a Currency List
        public static class CurrencyList
        {
            public static List<Currency> currencys = new List<Currency>();
            public static List<Currency> GetCurrencyStart()
            {             
                currencys.Add(new Currency
                {
                    ID = "0",
                    nameCurrency = "USD",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "1",
                    nameCurrency = "EUR",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "2",
                    nameCurrency = "GBP",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "3",
                    nameCurrency = "CAD",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "4",
                    nameCurrency = "BRL",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "5",
                    nameCurrency = "CNY",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "6",
                    nameCurrency = "HKD",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "7",
                    nameCurrency = "JPY",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "8",
                    nameCurrency = "MXN",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "9",
                    nameCurrency = "NZD",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "10",
                    nameCurrency = "NOK",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "11",
                    nameCurrency = "RUB",
                    selected = false
                });

                currencys.Add(new Currency
                {
                    ID = "12",
                    nameCurrency = "SEK",
                    selected = false
                });

                return currencys;
            }

             public static List<Currency> GetCurrency()
            {
                return currencys;
            }
        }

        private void CurrencyBoxList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CurrencyBoxList.SelectedItem == null)
            {   //Nothing happens
                return;
            }

            CurrencyList.currencys[CurrencyBoxList.SelectedIndex].selected = true;

            Currency currentCurrency = (Currency)CurrencyBoxList.SelectedItem;

            CurrencyConverter converterLast = new CurrencyConverter(currentCurrency.nameCurrency);

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        //Go to MainPage
        private void onClickMainImage(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}