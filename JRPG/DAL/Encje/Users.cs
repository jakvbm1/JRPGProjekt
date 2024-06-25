using MySql.Data.MySqlClient;

namespace JRPG.DAL.Encje
{
    class Users
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    
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
            string IsEquip = reader.GetInt32("PlayerOrAdmin").ToString();
            if (IsEquip == "1") IsAdmin = true;
            else IsAdmin = false;
            //IsAdmin = reader.GetBoolean("PlayerOrAdmin");

        }
        public string ToInsert()
        {
            if (IsAdmin) return $"('{Email}', '{Password}', '{Username}', '1')";
            else return $"('{Email}', '{Password}', '{Username}', '0')";
        }
    }
}
