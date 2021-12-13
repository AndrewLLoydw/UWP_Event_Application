using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EventApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inputRegisterUser.Visibility = Visibility.Visible;
            showUserInformationLW.Visibility = Visibility.Collapsed;
            btnCloseUserInfoLW.Visibility = Visibility.Collapsed;
        }

        private void btnGenerateCode_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnRegisterUserDone_Click(object sender, RoutedEventArgs e)
        {
            inputRegisterUser.Visibility = Visibility.Collapsed;
        }

        private void btnClickShowList_Click(object sender, RoutedEventArgs e)
        {
            showUserInformationLW.Visibility = Visibility.Visible;
            btnCloseUserInfoLW.Visibility = Visibility.Visible;
            inputRegisterUser.Visibility = Visibility.Collapsed;
        }

        private void btnCloseUserInfoLW_Click(object sender, RoutedEventArgs e)
        {
            showUserInformationLW.Visibility = Visibility.Collapsed;
            btnCloseUserInfoLW.Visibility = Visibility.Collapsed;
            inputRegisterUser.Visibility = Visibility.Collapsed;

        }
    }
}
