using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.ViewModels
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private string _name;
        public string name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged("name");
            }
        }
        

        public MyViewModel()
        {
            name = "Bob";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)   //Custom method
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
