using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.DAL.Encje
{
    public enum Difficulty
    {
        easy,
        medium,
        hard
    }
    class Enemies
    {
        public string EnemyName { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public string SpriteSet { get; set; }
        public int Defense { get; set; }
        public Difficulty Difficulty { get; set; }

        public Enemies(MySqlDataReader reader)
        {
            EnemyName = reader["Enemy_Name"].ToString();
            Health = int.Parse(reader["Health"].ToString());
            Attack = int.Parse(reader["Attack"].ToString());
            SpriteSet = reader["SpriteSet"].ToString();
            Defense = int.Parse(reader["Defense"].ToString());
            string Diff = reader["Difficulty"].ToString();
            if (Diff == "easy") Difficulty = Difficulty.easy;
            else if (Diff == "medium") Difficulty = Difficulty.medium;
            else if (Diff == "hard") Difficulty = Difficulty.hard;
        }
        public Enemies(string enemyName, int health, int attack, string spriteSet, int defense, Difficulty difficulty)
        {
            EnemyName=enemyName;
            Health=health;
            Attack=attack;
            SpriteSet = spriteSet;
            Defense = defense;
            Difficulty = difficulty;
        }
    }
}
