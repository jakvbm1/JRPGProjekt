using MySql.Data.MySqlClient;

namespace JRPG.DAL.Encje
{

    class Classes
    {
        public string ClassName { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public string SpriteSet { get; set; }
        public int Defense { get; set; }
        public Difficulty Difficulty { get; set; }

        public Classes(MySqlDataReader reader)
        {
            ClassName = reader["Class_Name"].ToString();
            Health = int.Parse(reader["Health"].ToString());
            Attack = int.Parse(reader["Attack"].ToString());
            SpriteSet = reader["SpriteSet"].ToString();
            Defense = int.Parse(reader["Defense"].ToString());
            string Diff = reader["Difficulty"].ToString();
            if (Diff == "easy") Difficulty = Difficulty.easy;
            else if (Diff == "medium") Difficulty = Difficulty.medium;
            else if (Diff == "hard") Difficulty = Difficulty.hard;
        }
        public Classes(string className, int health, int attack, string spriteSet, int defense, Difficulty difficulty)
        {
            ClassName = className;
            Health = health;
            Attack = attack;
            SpriteSet = spriteSet;
            Defense = defense;
            Difficulty = difficulty;
        }
    }
}
