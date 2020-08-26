using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPrismApp.ViewModels
{
    class MainViewModel : BindableBase
    {
        private string displayName;
        public string DisplayName
        {
            get => displayName;
            set => SetProperty(ref displayName, value);
        }

        private bool isEnabled;
        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                SetProperty(ref isEnabled, value);
                ExecuteCommand.RaiseCanExecuteChanged();
            }
        }

        private string updateText;
        public string UpdateText
        {
            get => updateText;
            set => SetProperty(ref updateText, value);
        }

        public DelegateCommand ExecuteCommand { get; set; }
        public MainViewModel()
        {
            DisplayName = "Prism App";
            ExecuteCommand = new DelegateCommand(Execute,CanExecute);
        }

        private void Execute()
        {
            UpdateText = $"Updated : {DateTime.Now}";
        }

        private bool CanExecute()
        {
            return IsEnabled;
        }
    }
}
