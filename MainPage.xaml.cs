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

namespace EventApp
{

    enum savedStatus
    {
        Added,
        Removed

    }

    public sealed partial class MainPage : Page
    {
        private string ChangeStatusText(savedStatus status)
        {
            switch (status)
            {
                case savedStatus.Added:
                    return "Du har lagts till i evenemanget...";

                case savedStatus.Removed:
                    return "Du har tagits bort från evenemanget...";

                default:
                    return "";
            }
        }

        private static string _savedStatus;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inputRegisterUser.Visibility = Visibility.Visible;
            btnCloseUserInfoLW.Visibility = Visibility.Visible;
            registerUsersText.Visibility=Visibility.Visible;
            listUsersText.Visibility = Visibility.Collapsed;
            showUserInformationLW.Visibility = Visibility.Collapsed;


        }

        private void btnGenerateCode_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int generateNum = rnd.Next(10000000, 99999999);

            generatedCode.Text = generateNum.ToString();


        }

        private void btnRegisterUserDone_Click(object sender, RoutedEventArgs e)
        {
            userStatusMessage.Text = ChangeStatusText(savedStatus.Added);



            userFirstNameInput.Text = "";
            userLastNameInput.Text = "";
            userEmailInput.Text = "";
            userAllergicInput.Text = "";

        }

        private void btnClickShowList_Click(object sender, RoutedEventArgs e)
        {
            showUserInformationLW.Visibility = Visibility.Visible;
            btnCloseUserInfoLW.Visibility = Visibility.Visible;
            listUsersText.Visibility = Visibility.Visible;
            inputRegisterUser.Visibility = Visibility.Collapsed;
            registerUsersText.Visibility = Visibility.Collapsed;
        }

        private void btnCloseUserInfoLW_Click(object sender, RoutedEventArgs e)
        {
            showUserInformationLW.Visibility = Visibility.Collapsed;
            btnCloseUserInfoLW.Visibility = Visibility.Collapsed;
            inputRegisterUser.Visibility = Visibility.Collapsed;
            listUsersText.Visibility = Visibility.Collapsed;
            registerUsersText.Visibility = Visibility.Collapsed;

        }

        private void btnDeleteUserInfo_Click(object sender, RoutedEventArgs e)
        {
            userStatusMessage.Text = ChangeStatusText(savedStatus.Removed);


        }


       
    }
}
