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
using System.Windows.Shapes;
using Business;
using static UI.UIProperties;

namespace UI
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private LoginWindow _loginWindow;

        public RegisterWindow()
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

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(UsernameBox.Text) || string.IsNullOrEmpty(PasswordBox.Password) || string.IsNullOrEmpty(FirstnameBox.Text) || string.IsNullOrEmpty(LastnameBox.Text))
                    //Shows a message box with a warning
                    MessageBox.Show("All fields should be full!", "Warning", MessageBoxButton.OK);

                else
                {
                    //Creates new instance of user
                    User user = new User();

                    //Sets properties for the user
                    user.UserName = UsernameBox.Text;
                    user.PasswordHash = UserBusiness.HashPassword(PasswordBox.Password);
                    user.FirstName = FirstnameBox.Text;
                    user.LastName = LastnameBox.Text;

                    //Registers the user
                    userBusiness.Register(user);

                    //Sets the current user to user
                    currentUser = user;

                    //Hides the instance of the window
                    this.Hide();

                    if (_loginWindow == null)
                    {
                        //Creates a new register window
                        _loginWindow = new LoginWindow();
                    }

                    //Shows the login window
                    _loginWindow.Show();

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
