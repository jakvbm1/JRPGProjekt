using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Model
{
    using JRPG.DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    class CharactersModel
    {
        public ObservableCollection<Characters> AllCharacters { get; set; } = new ObservableCollection<Characters>();

        public CharactersModel()
        {
           
            var allcharacters = RepoCharacters.GetAllCharacters();
            foreach (var character in allcharacters)
            {
               // Console.WriteLine(character.ToInsert());
                if (GlobalVariables.current_user != null && GlobalVariables.current_user.CharId == character.CharId) GlobalVariables.current_user = character;
                

                AllCharacters.Add(character);
            }
        }
        public bool AddCharacterToDatabase(Characters character)
        {
           if(RepoCharacters.AddCharacterToDatabase(character) == true)
            {
                AllCharacters.Clear();
                var allcharacters = RepoCharacters.GetAllCharacters();
                foreach (var zcharacter in allcharacters)
                {
                    // Console.WriteLine(character.ToInsert());
                    if (GlobalVariables.current_user != null && GlobalVariables.current_user.CharId == zcharacter.CharId) GlobalVariables.current_user = zcharacter;


                    AllCharacters.Add(zcharacter);
                }
                return true;
            }
            return false;
        }
        public bool UpdateGoldAndLevel(string Difficulty, Characters character)
        {
            return RepoCharacters.UpdateGoldAndLevel(Difficulty, character);
        }
       
    }
}
