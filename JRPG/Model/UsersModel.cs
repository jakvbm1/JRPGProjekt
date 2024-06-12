using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    class UsersModel
    {
    public ObservableCollection<Users>AllUsers { get; set; } = new ObservableCollection<Users>();
    
    
    public UsersModel() { 
        var allusers = RepoUsers.GetAllAnswers();
            foreach (var user in allusers)
            {
            AllUsers.Add(user);
            Console.WriteLine(user);    
            }
        
        }
    
    }
}
