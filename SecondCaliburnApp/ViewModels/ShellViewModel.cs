using Caliburn.Micro;
using MySql.Data.MySqlClient;
using SecondCaliburnApp.Helpers;
using SecondCaliburnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCaliburnApp.ViewModels
{
    class ShellViewModel : Conductor<object>, IHaveDisplayName
    {
        public override string DisplayName { get; set; }
        string firstName;

        public string FirstName 
        { 
            get => firstName; 
            set 
            { 
                firstName = value; 
                NotifyOfPropertyChange(() => FirstName); 
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }
        string lastName;
        
        public string LastName
        {
            get => lastName;
            set 
            {
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }
        public string FullName
        {
            get => $"{lastName} {firstName}";//string.Fomat("{0} {1}",FirstName,LastName);
        }
        public ShellViewModel()
        {
            DisplayName = "Second Caliburn App";

            People = new BindableCollection<PersonModel>();

            InitCombobox();
            //People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            //People.Add(new PersonModel { FirstName = "Bill", LastName = "Gates" });
            //People.Add(new PersonModel { FirstName = "Steve", LastName = "Jobs" });
        }

        private void InitCombobox()
        {
            People.Add(new PersonModel { LastName = "", FirstName = "--선택--" });
            using (MySqlConnection conn = new MySqlConnection(Commons.strConnString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.SELECTPEOPLEQUERY, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var temp = new PersonModel
                    {
                        FirstName = reader["firstname"].ToString(),
                        LastName = reader["lastname"].ToString()
                    };
                    People.Add(temp);
                }
            }
            SelectedPerson = People.Where(v => v.FirstName.Contains("선택")).First();

        }

        public BindableCollection<PersonModel> People { get; set; }

        PersonModel selectedPerson;

        public PersonModel SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                this.LastName = selectedPerson.LastName;
                this.FirstName = selectedPerson.FirstName;
                NotifyOfPropertyChange(() => SelectedPerson);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }
        public void ClearName()
        {
            this.FirstName = this.LastName = string.Empty;
        }

        public bool CanClearName
        {
            get => !(string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName));
            
        }
        public void LoadPageOne()
        {   //UserControl FirstChildView
            ActivateItem(new FirstChildViewModel());

        }
        public void LoadPageTwo()
        {   //UserControl SecondChildView
            ActivateItem(new SecondChildViewModel());

        }
    }
}
