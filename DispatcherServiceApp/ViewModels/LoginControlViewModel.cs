using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DispatcherServiceApp
{
    public class LoginControlViewModel : BaseViewModel
    {
        private string _login;
        private string _password;

        private List<Employee> Logins;

        public LoginControlViewModel()
        {
            LoginCommand=new RelayCommand(LoginProgram,CanLoginProgram);
            
            using (ApplicationContext context=new ApplicationContext ())
            {
                Logins=context.Employees.ToList();
            }
        }

        private bool CanLoginProgram(object arg)
        {
           var login=Logins.FirstOrDefault(e=>e.Login.Equals(_login?.Trim()));
            if (login!=null && login.Password.Equals(_password?.Trim()))
            {
                return true;
            }
            return false;
        }

        private void LoginProgram(object obj)
        {
            var window=(MainWindow)Application.Current.MainWindow;
            window.AddMainControl(new MainControl());            
        }

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login=value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password=value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; set; }

    }
}
