using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JRPG.DAL.Encje
{
    using DAL.Encje;
    using Fantasia.DAL.Encje;

    class Users
    {
        public string Email;
        public string Password;
        public string Username;
        public bool IsAdmin;
        public Characters current_user;
    
        public Users(string email, string password, string username, bool isAdmin)
        {
            Email = email;
            Password = password;
            Username = username;
            IsAdmin = isAdmin;
        }
        public Users(MySqlDataReader reader) { 
            Email = reader.GetString("Email");
            Password = reader.GetString("Password");
            Username = reader.GetString("Username");
            IsAdmin = reader.GetBoolean("PlayerOrAdmin");

        }
        public string ToInsert()
        {
            if (IsAdmin) return $"('{Email}', '{Password}', '{Username}', '1')";
            else return $"('{Email}', '{Password}', '{Username}', '0')";
        }
    }
}
