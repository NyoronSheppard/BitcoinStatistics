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
using System.Windows.Media;
using BitcoinStatistics.Models;

namespace BitcoinStatistics
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        //Index Item
        int indexItem;

        //DataBase
        public DataBaseContext DataB { get; set; }

        // Constructor
        public DetailsPage()
        {

            DataB = new DataBaseContext("Data Source=isostore:/DB.sdf");

            InitializeComponent();

            //Code to translate ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        //When navigating to the page to set the data context in the selected list item
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    int index = int.Parse(selectedIndex);
                    indexItem = index;
                    DataContext = App.ViewModel.Items[index];
                }
            }
        }

        //Change Tile
        private void TileButton_Click(object sender, EventArgs e)
        {
            //Statics values from TileUpdate

            Models.TileUpdate.seeTile = true;

            Models.TileUpdate.modelTile = App.ViewModel.Items[indexItem].NameApi;
            Models.TileUpdate.valueTile = App.ViewModel.Items[indexItem].LastValue;
            Models.TileUpdate.currencyTile = App.ViewModel.Items[indexItem].CurrencyApi;
            Models.TileUpdate.updateTile = App.ViewModel.Items[indexItem].LastUpdate;

            Models.TileUpdate.createOrUpdateTile();

            DataB.Tile.InsertOnSubmit(new TileUpdateDB { TileUpdateId = Models.TileUpdate.idTile+1, 
                                                         ModelTile = Models.TileUpdate.modelTile,
                                                         UpdateTile = Models.TileUpdate.updateTile,
                                                         SeeTile = Models.TileUpdate.seeTile,
                                                         ValueTile = Models.TileUpdate.valueTile,
                                                         CurrencyTile = Models.TileUpdate.currencyTile});
            DataB.SubmitChanges();

            //Tile Created
            updatedTile.Text = "     The icon has been created successfully";
        }

        //Go to MainPage
        private void onClickMainPage(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
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