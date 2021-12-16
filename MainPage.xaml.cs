using EventApp.Models;
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

        private static List<UserInfo> users = new List<UserInfo>();

        public MainPage()
        {
            this.InitializeComponent();

            if (users.Count > 0)
                lvUsers.ItemsSource = users;

        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {

            OpenRegisterWindowButton();

        }

        private void btnRegisterUserDone_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbEmail.Text))
            {
                users.Add(new UserInfo 
                { 
                    FirstName = tbFirstName.Text, 
                    LastName = tbLastName.Text, 
                    Email = tbEmail.Text, 
                    Allergies = tbAllergies.Text ?? "", 
                    DiscountCode = tbDiscount.Text ?? "" 
                });

                lvUsers.ItemsSource = users;

                tbFirstName.Text = ""; tbLastName.Text = ""; tbEmail.Text = ""; tbAllergies.Text = ""; tbDiscount.Text = "";

            }



            userStatusMessage.Text = ChangeStatusText(savedStatus.Added);

        }

        private void btnClickShowList_Click(object sender, RoutedEventArgs e)
        {
            OpenListWindowButton();
        }

        private void btnDeleteUserInfo_Click(object sender, RoutedEventArgs e)
        {

            var obj = (Button)sender;
            var item = (UserInfo)obj.DataContext;

            lvUsers.Items.Remove(item);

            userStatusMessage.Text = ChangeStatusText(savedStatus.Removed);


        }

        private void btnCloseUserInfoLW_Click(object sender, RoutedEventArgs e)
        {
            CloseWindowButton();
        }

        private void btnGenerateCode_Click(object sender, RoutedEventArgs e)
        {
            GenerateRandomCode();

        }

        // Methods to close other active buttons/fields.

        public void OpenRegisterWindowButton()
        {
            inputRegisterUser.Visibility = Visibility.Visible;
            btnCloseUserInfoLW.Visibility = Visibility.Visible;
            registerUsersText.Visibility = Visibility.Visible;
            listUsersText.Visibility = Visibility.Collapsed;
            lvUsers.Visibility = Visibility.Collapsed;
        }

        public void OpenListWindowButton()
        {
            lvUsers.Visibility = Visibility.Visible;
            btnCloseUserInfoLW.Visibility = Visibility.Visible;
            listUsersText.Visibility = Visibility.Visible;
            inputRegisterUser.Visibility = Visibility.Collapsed;
            registerUsersText.Visibility = Visibility.Collapsed;
        }

        public void CloseWindowButton()
        {
            lvUsers.Visibility = Visibility.Collapsed;
            btnCloseUserInfoLW.Visibility = Visibility.Collapsed;
            inputRegisterUser.Visibility = Visibility.Collapsed;
            listUsersText.Visibility = Visibility.Collapsed;
            registerUsersText.Visibility = Visibility.Collapsed;
        }

        //Method to generate a random discount code

        private void GenerateRandomCode()
        {
            Random rnd = new Random();
            int generateNum = rnd.Next(10000000, 99999999);

            generatedCode.Text = generateNum.ToString();
        }

        public void RemoveUser()
        {


        }
    }
}

