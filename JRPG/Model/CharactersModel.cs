using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using Fantasia.DAL.Encje;
    using System.Collections.ObjectModel;
    class CharactersModel
    {
        public ObservableCollection<Characters> AllCharacters { get; set; } = new ObservableCollection<Characters>();

        public CharactersModel()
        {
            var allcharacters = RepoCharacters.GetAllCharacters();
            foreach (var character in allcharacters)
            {
                AllCharacters.Add(character);
            }
        }
        public bool AddCharacterToDatabase(Characters character)
        {
            if (RepoCharacters.AddCharacterToDatabase(character)) { return true; }
            return false;
        }
    
    }
}
