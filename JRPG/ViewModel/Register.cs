﻿using System;
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
    using Fantasia.DAL.Encje;

    class Register: ViewModelBase
    {
        private MainModel model;
        private ObservableCollection<Users> users;
        private ObservableCollection<Characters> characters;
        private string? email;
        private string? Loginemail;
        private string? Loginpassword;
        private string? password;
        private string? username;
        private string? isadmin;
        public static Boolean logged;
        private Visibility visible=Visibility.Hidden;
        public Register(MainModel mainModel)
        {
           model = mainModel;
           users = model.usersModel.AllUsers;
           characters = model.charactersModel.AllCharacters; 
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
                                var user = new Users(Email, Password, Username, false);

                                
                                if (model.usersModel.AddUserToDatabase(user))
                                {
                                    System.Windows.MessageBox.Show("User was added to database!");
                                    Email = "";
                                    Password = "";
                                    Username = "";
                                    IsAdmin = "";
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
                                                Users.current_user = charakt;
                                            }
                                        }
                                        
                                        
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






