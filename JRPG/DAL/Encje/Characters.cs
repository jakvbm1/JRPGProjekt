using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasia.DAL.Encje
{
    class Characters
    {
        public string Username { get; set; }
        public int ExpLevel { get; set; }
        public int Gold { get; set; }
        public string Class_Name { get; set; }

        public Characters(MySqlDataReader reader)
        {
            Username = reader["Username"].ToString();
            ExpLevel = int.Parse(reader["Exp_Level"].ToString());
            Gold = int.Parse(reader["Gold"].ToString());
            Class_Name = reader["Class_Name"].ToString();
        }

        public Characters(string Username, int ExpLevel, int Gold, string Class_Name)
        {
            this.Username = Username;
            this.ExpLevel = ExpLevel;
            this.Gold = Gold;
            this.Class_Name = Class_Name;
        }
        
    
    }
}
