using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static UI.UIProperties;
using Business;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private RegisterWindow _registerWindow;
        private MainWindow _mainWindow;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Allows to drag move the Window while clicking on this instance
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //Shuts down the Application
            Application.Current.Shutdown();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            //Hides the instance of the window
            this.Hide();

            if (_registerWindow == null)
            {
                //Creates a new register window
                _registerWindow = new RegisterWindow();
            }

            //Shows the register window
            _registerWindow.Show();

            //Closes the instance of this window
            this.Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(UsernameBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");

                else
                {
                    //Sets the current user
                    currentUser = userBusiness.FetchUser(UsernameBox.Text, UserBusiness.HashPassword(PasswordBox.Password));
                    
                    //Hides the instance of the window
                    this.Hide();

                    if (_mainWindow == null)
                    {
                        //Creates a new main window
                        _mainWindow = new MainWindow();
                    }

                    //Sets the HomeView Label
                    _mainWindow.HomeView.HomeLabel.Content += currentUser.UserName[0].ToString().ToUpper() + currentUser.UserName.Substring(1).ToLower() + "!";

                    //Shows the main window
                    _mainWindow.Show();

                    //Closes the instance of this window
                    this.Close();
                }
            }
            catch(Exception exception)
            {
                //Shows the message of the current exception
                ShowError(exception.Message);
            }
        }
    }
}
