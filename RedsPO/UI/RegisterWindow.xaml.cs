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
        /// <summary>The login window</summary>
        private LoginWindow _loginWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterWindow"/> class.
        /// </summary>
        public RegisterWindow()
        {
            InitializeComponent();
        }

        /// <summary>Handles the MouseLeftButtonDown event of the Grid control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Allows to drag move the Window while clicking on this instance
            this.DragMove();
        }

        /// <summary>Handles the Click event of the CloseButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //Shuts down the Application
            Application.Current.Shutdown();
        }

        /// <summary>Handles the Click event of the SubmitButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(UsernameBox.Text) || string.IsNullOrEmpty(PasswordBox.Password) || string.IsNullOrEmpty(FirstnameBox.Text) || string.IsNullOrEmpty(LastnameBox.Text))
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");

                else
                {
                    //Creates new instance of user
                    User user = new User
                    {
                        //Sets properties for the user
                        UserName = UsernameBox.Text,
                        PasswordHash = UserBusiness.HashPassword(PasswordBox.Password),
                        FirstName = FirstnameBox.Text,
                        LastName = LastnameBox.Text
                    };

                    //Registers the user
                    userBusiness.Register(user);

                    //Hides the instance of the window
                    this.Hide();

                    if (_loginWindow == null)
                    {
                        //Creates a new main window
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
