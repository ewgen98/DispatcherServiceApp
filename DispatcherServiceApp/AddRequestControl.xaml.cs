using MaterialDesignThemes.Wpf;
using System.Windows.Controls;

namespace DispatcherServiceApp
{
    /// <summary>
    /// Логика взаимодействия для AddRequestControl.xaml
    /// </summary>
    public partial class AddRequestControl : UserControl
    {
        public AddRequestControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogHost.CloseDialogCommand.Execute(true,btn);
        }
    }
}
