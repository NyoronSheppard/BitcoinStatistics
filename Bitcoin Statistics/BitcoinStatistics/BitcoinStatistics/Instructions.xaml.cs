using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BitcoinStatistics
{
    public partial class Instructions : PhoneApplicationPage
    {
        public Instructions()
        {
            InitializeComponent();
        }

        //Go to Main Page
        private void onClickMainImage(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}