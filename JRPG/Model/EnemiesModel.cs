using JRPG.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    class EnemiesModel
    {
    public ObservableCollection<Enemies> AllEnemies { get; set; } = new ObservableCollection<Enemies>();
    
    public EnemiesModel() { 
        var allenemies = RepoEnemies.GetAllEnemies();
        foreach (var enemies in allenemies)
            {
                AllEnemies.Add(enemies);
            }
        
        }

        public ObservableCollection<Enemies> GetEnemiesByDifficulty(Difficulty difficulty)
        {
            ObservableCollection<Enemies> enemies = new ObservableCollection<Enemies>();
            foreach (var enemy in AllEnemies)
            {
                if (enemy.Difficulty == difficulty)
                {
                    enemies.Add(enemy);
                }

            }
            return enemies;
        }


    
    
    }
   

}
