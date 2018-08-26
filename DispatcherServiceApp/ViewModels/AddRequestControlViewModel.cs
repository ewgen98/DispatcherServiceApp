using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DispatcherServiceApp
{
    public class AddRequestControlViewModel : BaseViewModel
    {
        private Document _document;
        public AddRequestControlViewModel()
        {
            _document = new Document();
        }
        public AddRequestControlViewModel(Document document)
        {
            _document = document;
        }

        public string FName
        {
            get => _document.FName;
            set
            {
                _document.FName = value;
                OnPropertyChanged(nameof(FName));
            }
        }

        public string SName
        {
            get => _document.SName;
            set
            {
                _document.SName = value;
                OnPropertyChanged(nameof(SName));
            }
        }

        public string LName
        {
            get => _document.LName;
            set
            {
                _document.LName = value;
                OnPropertyChanged(nameof(LName));
            }
        }

        public string Phone
        {
            get => _document.Phone;
            set
            {
                _document.Phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public string Street
        {
            get => _document.Street;
            set
            {
                _document.Street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        public int? HomeNumber
        {
            get => _document.HomeNumber;
            set
            {
                _document.HomeNumber = value;
                OnPropertyChanged(nameof(HomeNumber));
            }
        }

        public int? Apartment
        {
            get => _document.Apartment;
            set
            {
                _document.Apartment = value;
                OnPropertyChanged(nameof(Apartment));
            }
        }

        public string DescriptionProblem
        {
            get => _document.DescriptionProblem;
            set
            {
                _document.DescriptionProblem = value;
                OnPropertyChanged(nameof(DescriptionProblem));
            }
        }

        public string Worker
        {
            get => _document.Worker;
            set
            {
                _document.Worker = value;
                OnPropertyChanged(nameof(Worker));
            }
        }

        public string FirstDate
        {
            get => _document.FirstDate;
            set
            {
                _document.FirstDate =  value;
                OnPropertyChanged(nameof(FirstDate));
            }
        }

        public string LastDate
        {
            get => _document.LastDate;
            set
            {
                _document.LastDate = value;
                OnPropertyChanged(nameof(LastDate));
            }
        }

        public string DescriptionResult
        {
            get => _document.DescriptionResult;
            set
            {
                _document.DescriptionResult = value;
                OnPropertyChanged(nameof(DescriptionResult));
            }
        }

        public decimal Money
        {
            get => _document.Money;
            set
            {
                _document.Money = value;
                OnPropertyChanged(nameof(Money));
            }
        }

        public ICommand AddCommand => new RelayCommand(Add);

        private void Add(object obj)
        {
            using (var db = new ApplicationContext())
            {
                var doc = db.Documents.Find(_document.Id);
                if (doc != null)
                {
                    doc.FName = _document.FName;
                    doc.SName = _document.SName;
                    doc.LName = _document.LName;
                    doc.Phone = _document.Phone;
                    doc.Street = _document.Street;
                    doc.HomeNumber = _document.HomeNumber;
                    doc.Apartment = _document.Apartment;
                    doc.DescriptionProblem = _document.DescriptionProblem;
                    doc.Worker = _document.Worker;
                    doc.FirstDate = _document.FirstDate;
                    doc.LastDate = _document.LastDate;
                    doc.DescriptionResult = _document.DescriptionResult;
                    doc.Money = _document.Money;
                    db.Entry(doc).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return;
                }
                db.Documents.Add(_document);
                db.SaveChanges();
            }
        }
    }
}
