using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace JRPG.ViewModel
{
    using DAL.Encje;
    using Model;
    using BaseClass;
    using System.Windows.Input;
    using System.Runtime.CompilerServices;

    class Register: ViewModelBase
    {
        private MainModel model;
        private ObservableCollection<Users> users;
        private string? email;
        private string? password;
        private string? username;
        private string? isadmin;

        public Register(MainModel mainModel)
        {
           model = mainModel;
           users = model.usersModel.AllUsers;
        }

        public string? Email
        {
            get { return email; }
            set
            {
                email = value;
          
                onPropertyChanged(nameof(Email));
            }
        }
        public string? Password
        {
            get { return password; }
            set
            {
                password = value;
                onPropertyChanged(nameof(Password));
            }
        }
       public string? Username
            {
            get { return username; }
            set
            {
                username = value;
                onPropertyChanged(nameof(Username));
            }
        }

        public string? IsAdmin
            {
            get { return isadmin; }
            set
            {
                isadmin = value;
                onPropertyChanged(nameof(IsAdmin));
            }

            }

        private ICommand addUser = null;
        public ICommand AddUser
        {
            get
            {
                if (addUser == null)
                    addUser = new RelayCommand(
                        arg =>
                        {

                            if (!string.IsNullOrEmpty(Email) & !string.IsNullOrEmpty(Password) & !string.IsNullOrEmpty(Username))
                            {
                                var user = new Users(Email, Password, Username, false);
                                Console.WriteLine(Email);

                                if (model.usersModel.AddUserToDatabase(user))
                                {
                                    System.Windows.MessageBox.Show("User was added to database!");
                                    Email = "";
                                    Password = "";
                                    Username = "";
                                    IsAdmin = "";
                                }
                            }
                            else { System.Windows.MessageBox.Show("Every box needs to be filled"); }
                            
                            
                        },
                        arg => (1 > 0)
                        );

                return addUser;
            }
        }

    }
    }






