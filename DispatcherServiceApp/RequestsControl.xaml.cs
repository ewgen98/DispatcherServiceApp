using DispatcherServiceApp.ViewModels;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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

namespace DispatcherServiceApp
{
    /// <summary>
    /// Логика взаимодействия для RequestsControl.xaml
    /// </summary>
    public partial class RequestsControl : UserControl
    {
        public RequestsControl()
        {
            InitializeComponent();
            DataContext=new RequestsControlViewModel();
            TrainsitionigContentSlide.OpeningEffect = new TransitionEffect(TransitionEffectKind.SlideInFromRight, new TimeSpan(0, 0, 0, 0, 800));
        }
    }
}
