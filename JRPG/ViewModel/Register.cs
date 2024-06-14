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
    using System.Windows;
    using JRPG.DAL.Repozytoria;

    class Register: ViewModelBase
    {
        private MainModel model;
        private ObservableCollection<Users> users;
        private ObservableCollection<Characters> characters;
        private ObservableCollection<Classes> classes;
        private ObservableCollection<string>? classNames = new ObservableCollection<string>();
        private string? email;
        private string? Loginemail;
        private string? Loginpassword;
        private string? password;
        private string? username;
        private string? isadmin;
        private string? selectedClass;
        public static Boolean logged;
        private Visibility visible=Visibility.Hidden;
        public Register(MainModel mainModel)
        {
           model = mainModel;
           users = model.usersModel.AllUsers;
           characters = model.charactersModel.AllCharacters; 
           classes = model.classesModel.AllClasses;
            foreach (var clas in classes) { 
                classNames.Add(clas.ClassName);
            }
        }

        public Visibility Visible
        {
            get { return visible; }
            set
            {
                visible = value;

                onPropertyChanged(nameof(Visible));
            }
        }

        public string? SelectedClass
        {
            get { return selectedClass; }
            set { 
                selectedClass = value;
                onPropertyChanged(nameof(SelectedClass));
            }
        }
        

        public ObservableCollection<string>? ClassNames
        {
            get { return classNames; }
            set
            {
                {
                    classNames = value;
                    onPropertyChanged(nameof(ClassNames));

                }
            }
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

        public string? LoginEmail
        {
            get { return Loginemail; }
            set
            {
                Loginemail = value;

                onPropertyChanged(nameof(LoginEmail));
            }
        }

        public string? LoginPassword
        {
            get { return Loginpassword; }
            set
            {
                Loginpassword = value;

                onPropertyChanged(nameof(LoginPassword));
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
                                Users user = new Users(Email, Password, Username, false);
                                
                                
                                    var character = new Characters(Email, 1, 10, selectedClass);
                                
                               
                                
                                if (model.usersModel.AddUserToDatabase(user))
                                {
                                    model.usersModel.AllUsers.Add(user);
                                    users = model.usersModel.AllUsers;
                                    System.Windows.MessageBox.Show("User was added to database!");
                                    Email = "";
                                    Password = "";
                                    Username = "";
                                    IsAdmin = "";


                                    if (model.charactersModel.AddCharacterToDatabase(character))
                                    {
                                        model.charactersModel.AllCharacters.Add(character);
                                        characters = model.charactersModel.AllCharacters;
                                        System.Windows.MessageBox.Show("character was added do database!");
                                        
                                    }
                                }
                            }
                            else {
                                
                                System.Windows.MessageBox.Show("Every box needs to be filled"); }
                            
                            
                        },
                        arg => (1 > 0)
                        );

                return addUser;
            }
        }
        private ICommand login = null;
        public ICommand Login
        {
            get
            {
                if (login == null)
                    login = new RelayCommand(
                        arg =>
                        {
                            foreach(var user in users)
                            {
                               
                                if (user.Email == LoginEmail)
                                {
                                
                                    if (user.Password == LoginPassword) {
                                        foreach(var charakt in characters)
                                            {
                                           if(charakt.Usermail == LoginEmail)
                                            {
                                                GlobalVariables.current_user = new Characters(charakt);
                                                //GlobalVariables.current_user = charakt;
                                               // Users.current_user = charakt;
                                            }
                                        }

                                        GlobalVariables.cur_username = user.Username;
                                        Visible = Visibility.Visible;

                                        break;
                                        
                                    }
                                    
                                        
                                    else logged = false;
                                }
                            }
                            


                        },
                        arg => (1 > 0)
                        );

                return login;
            }
        }



    }
    }






