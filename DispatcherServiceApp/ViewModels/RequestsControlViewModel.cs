using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using DispatcherServiceApp.Infra;
using MaterialDesignThemes.Wpf;

namespace DispatcherServiceApp.ViewModels
{
    public class RequestsControlViewModel : INotifyPropertyChanged
    {
        public ICommand AddRequestCommand => new RelayCommand(AddRequest);
        public ICommand DeleteRequestCommand=>new RelayCommand(DeleteRequest);

        private async void DeleteRequest(object obj)
        {
            var view=new DeleteControl();
            var result=await DialogHost.Show(view,"RootDialog");
        }

        private async void AddRequest(object o)
        {
            var view = new AddRequestControl
            {
                DataContext = null
            };
            var result = await DialogHost.Show(view, "RootDialog");
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
