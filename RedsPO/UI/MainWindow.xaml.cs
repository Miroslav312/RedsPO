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
using static UI.UIProperties;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>Handles the MouseLeftButtonDown event of the Grid control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
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

        /// <summary>Handles the Click event of the EventButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void EventButton_Click(object sender, RoutedEventArgs e)
        {
            if (!MainBody.Children.Contains(eventView))
            {
                //Removes all elements
                MainBody.Children.Clear();

                //Adds the user control
                MainBody.Children.Add(eventView);
            }
        }

        /// <summary>Handles the Click event of the ReminderButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ReminderButton_Click(object sender, RoutedEventArgs e)
        {
            if (!MainBody.Children.Contains(reminderView))
            {
                //Removes all elements
                MainBody.Children.Clear();

                //Adds the user control
                MainBody.Children.Add(reminderView);
            }
        }
    }
}
