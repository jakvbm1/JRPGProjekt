using JRPG.DAL.Encje;

namespace JRPG.DAL.Repozytoria
{

    static class GlobalVariables
    {
        public static Characters current_user {  get; set; }
        public static string cur_username { get; set; }
        public static bool isadmin { get; set; }

    }
}
