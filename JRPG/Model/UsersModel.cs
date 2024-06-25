namespace JRPG.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    class UsersModel
    {
        public ObservableCollection<Users>AllUsers { get; set; } = new ObservableCollection<Users>();
    
    
        public UsersModel() { 
        var allusers = RepoUsers.GetAllUsers();
            foreach (var user in allusers)
            {
            AllUsers.Add(user);
              
            }
        
        }
        public bool AddUserToDatabase(Users user)
        {
            if (RepoUsers.AddUserToDatabase(user)) {
                return true;
            }
        
        return false;}

        public bool UpdateAdmin(Users user)
        {
            return RepoUsers.UpdateAdmin(user);
        }

    }
    
}
