
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
    class ClassesModel
    {
    
    public ObservableCollection<Classes>AllClasses {  get; set; } = new ObservableCollection<Classes>();

    public ClassesModel() { 
        var allclasses = RepoClasses.GetAllClasses();
            foreach (var c in allclasses)
            {
                AllClasses.Add(c);            
            }
        }
    
    
    }
}
