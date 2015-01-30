using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BitcoinStatistics.Resources;
using BitcoinStatistics.ViewModels;
using BitcoinStatistics.Models;
using System.Globalization;
using System.Data.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace BitcoinStatistics
{
    public static class Constants
    {
        public const int numberStore = 5; // Total old values
    }
    public partial class MainPage : PhoneApplicationPage
    {

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //Set the data context of LongListSelector control data
            DataContext = App.ViewModel;

            //Code to translate ApplicationBar
            //BuildLocalizedApplicationBar();
            
            updateGeneralData();
        }

        //Load data for the ViewModel elements
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        //Controller selection changed in LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If the selected item is NULL (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            //Navigate to the next page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID, UriKind.Relative));

            //Reset selected element null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

        //Refresh the main page
        private void onClickRefreshButton(object sender, EventArgs e)
        {    
            string[] arrayOldValues = new string[Constants.numberStore];
            string[] arrayOldCurrency = new string[Constants.numberStore];
            int i = 0;
            int j = 0;

            //Copy LastValue in OldValue
            foreach (var value in App.ViewModel.Items)
            {              
                //Save with USD currency
                if (i < Constants.numberStore)
                {
                    arrayOldValues[i] = value.LastValueUSD;
                }
                
                //arrayOldCurrency[i] = value.CurrencyApi;
                i++;
            }

            App.ViewModel.LoadData();

            updateGeneralData();

            //Wait por Sleep(x) seconds
            System.Threading.ThreadPool.QueueUserWorkItem(obj =>
            {
                System.Threading.Thread.Sleep(2500);

                Dispatcher.BeginInvoke(() =>
                {
                    try
                    {
                        foreach (var value in App.ViewModel.Items)
                        {
                            if (float.Parse(arrayOldValues[j], CultureInfo.InvariantCulture.NumberFormat) < float.Parse(value.LastValue, CultureInfo.InvariantCulture.NumberFormat))
                            {
                                value.ArrowSource = "/Images/greenArrow4.png";

                                //Change color text to green
                                value.DifferenceColor = "#9928DC0C";
                            }
                            else if (float.Parse(arrayOldValues[j], CultureInfo.InvariantCulture.NumberFormat) > float.Parse(value.LastValue, CultureInfo.InvariantCulture.NumberFormat))
                            {
                                value.ArrowSource = "/Images/redArrow4.png";

                                //Change color text to red
                                value.DifferenceColor = "#99F70914";
                            }
                            else
                            {
                                value.ArrowSource = "/Images/equalIcon4.png";

                                //Change color text to normal
                                value.DifferenceColor = "#FFFFFFFF";
                            }

                            float difference = float.Parse(value.LastValue, CultureInfo.InvariantCulture.NumberFormat) / float.Parse(arrayOldValues[j], CultureInfo.InvariantCulture.NumberFormat);
                            
                            difference = difference - 1;

                            if (difference < 0)
                            {
                                value.Difference = difference.ToString("0.0000").Replace(',', '.') + " %"; 
                            }
                            else if (difference > 0)
                            {
                                value.Difference = "+" + difference.ToString("0.0000").Replace(',', '.') + " %";
                            }
                            else
                            {
                                value.Difference = difference.ToString() + " %";
                            }
                            
                            j++;

                            //Update Tile
                            if (Models.TileUpdate.seeTile == true)
                            {
                                if (value.NameApi == Models.TileUpdate.modelTile)
                                {
                                    Models.TileUpdate.valueTile = value.LastValue;
                                    Models.TileUpdate.currencyTile = value.CurrencyApi;
                                    Models.TileUpdate.updateTile = value.LastUpdate;
                                    
                                    Models.TileUpdate.createOrUpdateTile();
                                }
                            }
                        }

                        //CurrencyConverter converterLast = new CurrencyConverter(arrayOldCurrency[j]);
                    }
                    catch// (Exception ex)
                    {

                    }
                    
                });
            });


        }

        //Navigate to CurrencyList
        //private void onClickCurrencyList(object sender, EventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/CurrencyPage.xaml", UriKind.Relative));
        //}

        //Update general data
        public void updateGeneralData()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(obj =>
            {
                System.Threading.Thread.Sleep(2000);

                Dispatcher.BeginInvoke(() =>
                {
                    try
                    {
                        textUpdate.Text = App.ViewModel.Items[0].LastUpdate;
                        currencyType.Content = App.ViewModel.Items[0].CurrencyApi;
                    }
                    catch// (Exception ex)
                    {

                    }

                });
            });
        }

        private void currencyType_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CurrencyPage.xaml", UriKind.Relative));
        }

        //Go to About Page
        private void onClickAbout(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        //Go to Main Page
        private void onClickMainImage(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        //Go to Instructions Page
        private void onClickInstructions(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Instructions.xaml", UriKind.Relative));
        }

        // Código de ejemplo para compilar una ApplicationBar traducida
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Crear un nuevo elemento de menú con la cadena traducida de AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}