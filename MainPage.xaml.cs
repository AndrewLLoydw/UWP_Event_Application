using EventApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
        private StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        private StorageFile sampleFile;
        private string fileContent;


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

        public MainPage()
        {
            this.InitializeComponent();

            Task.Run(async () => await AddFileAsync("Users.csv")).Wait();

            if (!string.IsNullOrEmpty(fileContent))
            {
                using (StringReader sr = new StringReader(fileContent))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var values = line.Split(", ");

                        var user = new User { FirstName = values[0], LastName = values[1], Email = values[2], Allergies = values[3], DiscountCode = values [4]};


                        lvUsers.Items.Add(user);
                    }
                }
            }

        }
        

        private async Task AddFileAsync(string fileName)
        {
            try
            {
                sampleFile = await storageFolder.GetFileAsync(fileName);
            }
            catch
            {
                sampleFile = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            }


            await ReadFileAsync(sampleFile);
        }


        private async Task ReadFileAsync(StorageFile storageFile)
        {
            fileContent = await FileIO.ReadTextAsync(storageFile);
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {

            OpenRegisterWindowButton();

        }

        private async void btnRegisterUserDone_Click(object sender, RoutedEventArgs e)

        {
            var obj = (Button)sender;
            var item = (User)obj.DataContext;

            if (!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbEmail.Text))
            {   
                lvUsers.Items.Add(new User
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Email = tbEmail.Text,
                    Allergies = tbAllergies.Text ?? "",
                    DiscountCode = tbDiscount.Text ?? ""

                });

                await FileIO.AppendTextAsync(sampleFile, $"{tbFirstName.Text}, {tbLastName.Text}, {tbEmail.Text}, {tbAllergies.Text}, {tbDiscount.Text}\r\n");



                tbFirstName.Text = ""; tbLastName.Text = ""; tbEmail.Text = ""; tbAllergies.Text = ""; tbDiscount.Text = "";

            }

        userStatusMessage.Text = ChangeStatusText(savedStatus.Added);

        }

        private void btnClickShowList_Click(object sender, RoutedEventArgs e)
        {
            OpenListWindowButton();
        }

        private async void btnDeleteUserInfo_Click(object sender, RoutedEventArgs e)
        {

            var obj = (Button)sender;
            var item = (User)obj.DataContext;

            lvUsers.Items.Remove(item);

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
    }
}

