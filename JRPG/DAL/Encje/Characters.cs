﻿using MySql.Data.MySqlClient;

namespace JRPG.DAL.Encje
{
    class Characters
    {
        public int CharId { get; set; }
        public string Usermail { get; set; }
        public int ExpLevel { get; set; }
        public int Gold { get; set; }
        public string Class_Name { get; set; }


        public Characters(MySqlDataReader reader)
        {
            CharId = int.Parse(reader["CharId"].ToString());
            Usermail = reader["userMail"].ToString();
            ExpLevel = int.Parse(reader["Exp_Level"].ToString());
            Gold = int.Parse(reader["Gold"].ToString());
            Class_Name = reader["Class_Name"].ToString();
        }

        public Characters(Characters character)
        {
            this.CharId = character.CharId;
            this.Usermail = character.Usermail;
            ExpLevel = character.ExpLevel;
            Gold = character.Gold;
            Class_Name = character.Class_Name;
        }

        public Characters(string Usermail, int ExpLevel, int Gold, string Class_Name)
        {
            this.Usermail = Usermail;
            this.ExpLevel = ExpLevel;
            this.Gold = Gold;
            this.Class_Name = Class_Name;
        }
        public string ToInsert()
        {
            return $"('sf'{CharId}', '{Usermail}', '{ExpLevel}', '{Gold}', '{Class_Name}'";
        }
    }
}
