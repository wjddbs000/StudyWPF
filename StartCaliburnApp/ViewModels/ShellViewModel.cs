using Caliburn.Micro;
using System;
using System.Windows;
using System.Windows.Input;

namespace StartCaliburnApp.ViewModels
{
    public class ShellViewModel : PropertyChangedBase, IHaveDisplayName
    {
        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanSayHello);
            }
        }

        public bool CanSayHello 
        { 
            get => !string.IsNullOrEmpty(Name);
        }
        public string DisplayName { get; set; }

        public void SayHello()
        {
            MessageBox.Show($"Hello {Name}");
        }
    }

}
