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
using UI.UserControls.EventControls;

namespace UI.UserControls
{
    /// <summary>
    /// Interaction logic for EventUI.xaml
    /// </summary>
    public partial class EventView : UserControl
    {

        private AddEvent _addEvent = new AddEvent();

        public EventView()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!EventFunction.Children.Contains(_addEvent))
            {
                //Removes all elements
                EventFunction.Children.Clear();

                //Adds the user control
                EventFunction.Children.Add(_addEvent);
            }
        }
    }
}
