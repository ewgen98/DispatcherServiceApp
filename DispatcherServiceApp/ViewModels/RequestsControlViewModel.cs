using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;

namespace DispatcherServiceApp.ViewModels
{
    public class RequestsControlViewModel : BaseViewModel
    {
        private DocumentView _selectDocumentView;
        public RequestsControlViewModel()
        {
            GetDocuments();
        }
        public ObservableCollection<DocumentView> Documents { get; set; } = new ObservableCollection<DocumentView>();
        public ICommand AddRequestCommand => new RelayCommand(AddRequest);
        public ICommand DeleteRequestCommand => new RelayCommand(DeleteRequest, CanSelectRequest);
        public ICommand UpdateRequestCommand => new RelayCommand(UpdateRequest, CanSelectRequest);
        public ICommand ExportRequestCommand => new RelayCommand(ExportRequest, CanSelectRequest);

        private void ExportRequest(object obj)
        {
            WordHelper.Export(SelectDocumentView.Number);
        }

        private async void UpdateRequest(object obj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var doc = db.Documents.Find(SelectDocumentView.Number);
                var view = new AddRequestControl
                {
                    DataContext = new AddRequestControlViewModel(doc)
                };
                var result = await DialogHost.Show(view, "RootDialog");
                if ((bool) result)
                {
                    GetDocuments();
                }
            }
        }

        private bool CanSelectRequest(object arg)
        {
            return SelectDocumentView != null;
        }

        public DocumentView SelectDocumentView
        {
            get => _selectDocumentView;
            set
            {
                _selectDocumentView = value;
                OnPropertyChanged(nameof(SelectDocumentView));
            }
        }

        private async void DeleteRequest(object obj)
        {
            var view = new DeleteControl();
            var result = await DialogHost.Show(view, "RootDialog");
            if ((bool) result)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var doc = db.Documents.FirstOrDefault(d => d.Id == SelectDocumentView.Number);
                    db.Documents.Remove(doc);
                    db.SaveChanges();
                    GetDocuments();
                }
            }
        }
        private async void AddRequest(object o)
        {
            var view = new AddRequestControl
            {
                DataContext = new AddRequestControlViewModel()
            };
            var result = await DialogHost.Show(view, "RootDialog");
            if ((bool) result)
            {
                GetDocuments();
            }
        }

        private void GetDocuments()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Documents.Clear();
                foreach (var document in db.Documents.ToList())
                {
                    var firstDate =DateTime.ParseExact(document.FirstDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var lastDate =DateTime.ParseExact(document.LastDate, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var view = new DocumentView
                    {
                        Number = document.Id,
                        Addresses = $"ул. {document.Street}, д.{document.HomeNumber}, кв.№{document.Apartment}",
                        Declarer = $"{document.LName} {document.FName[0]}.{document.SName[0]}",
                        Executor = $"{document.Worker}",
                        FirstDate = firstDate.ToShortDateString(),
                        LastDate = lastDate.ToShortDateString()
                    };
                    Documents.Add(view);
                }
            }
        }
    }
}
