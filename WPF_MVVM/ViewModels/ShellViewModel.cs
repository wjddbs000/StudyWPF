﻿using System;
using System.Windows;
using System.Windows.Input;

namespace WPF_MVVM.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        #region 멤버변수/속성영역
        string inFirstName;
        string inLastName;
        string inEmail;
        DateTime? inDate;

        string outFirstName;
        string outLastName; 
        string outEmail; 
        string outDate;
        string outAdult;
        string outBirthday;
        string outChnZodiac; //200727 16:43 신규추가
        string outCalZodiac;

        public string InLastName
        {
            get => inLastName;
            set
            {
                inLastName = value;
                RaisePropertyChanged("InLastName");
            }
        }
        public string InFirstName
        {
            get => inFirstName;
            set
            {
                inFirstName = value;
                RaisePropertyChanged("InFirstName");
            }
        }
        public string InEmail
        {
            get => inEmail;
            set
            {
                inEmail = value;
                RaisePropertyChanged("InEmail");
            }
        }
        public DateTime? InDate
        {
            get => inDate;
            set
            {
                inDate = value;
                RaisePropertyChanged("InDate");
            }
        }
        public string OutFirstName
        {
            get => outFirstName;
            set
            {
                outFirstName = value;
                RaisePropertyChanged("outFirstName");
            }
        }
        public string OutLastName
        {
            get => outLastName;
            set
            {
                outLastName = value;
                RaisePropertyChanged("outLastName");
            }
        }
        public string OutEmail

        {
            get => outEmail;
            set
            {
                outEmail = value;
                RaisePropertyChanged("outEmail");
            }
        }
        public string OutDate
        {
            get => outDate;
            set
            {
                outDate = value;
                RaisePropertyChanged("outDate");
            }
        }
        public string OutAdult
        {
            get => outAdult;
            set
            {
                outAdult = value;
                RaisePropertyChanged("outAdult");
            }
        }
        public string OutBirthday
        {
            get => outBirthday;
            set
            {
                outBirthday = value;
                RaisePropertyChanged("outBirthday");
            }
        }
        public string OutChnZodiac
        {
            get => outChnZodiac;
            set
            {
                outChnZodiac = value;
                RaisePropertyChanged("outChnZodiac");
            }
        }//200727 16:43 신규추가
        public string OutCalZodiac
        {
            get => outCalZodiac;
            set
            {
                outCalZodiac = value;
                RaisePropertyChanged("outCalZodiac");
            }
        }
        #endregion

        ICommand clickCommand;
        public ICommand ClickCommand => clickCommand ?? (clickCommand = new RelayCommand<object>(o => Click(), o => IsClick()));

        private void Click()
        {
            try
            {
                DateTime date = InDate ?? DateTime.Now;
                Person person = new Person(InFirstName, InLastName, InEmail, date);

                OutLastName = person.LastName;
                OutFirstName = person.FirstName;
                OutEmail = person.Email;
                OutDate = person.Date.ToShortDateString();
                OutAdult = $"{person.IsAdult}";
                OutBirthday = $"{person.IsBirthDay}";
                OutChnZodiac = person.ChnZodiac(); //200727 16:43 신규추가
                OutCalZodiac = person.CalZodiac();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}" );
            }
        }

        private bool IsClick()
        {
            return (!string.IsNullOrEmpty(InLastName)) &&
                !string.IsNullOrEmpty(InFirstName) &&
                !string.IsNullOrEmpty(InEmail) &&
                !string.IsNullOrEmpty(InDate.ToString());
        }
    }

}
