using System.Windows;
using System.Windows.Controls;

namespace CarRental_Director.View
{
    public partial class CarView : UserControl
    {
        public CarView()
        {
            InitializeComponent();
        }

        private void StackPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Workspace.ActualHeight > header.ActualHeight)
            {
                MainSB.Height = Workspace.ActualHeight - header.ActualHeight;
            }
        }
    }
}
