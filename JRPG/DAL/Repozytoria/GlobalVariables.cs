﻿using JRPG.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.DAL.Repozytoria
{
    
    static class GlobalVariables
    {

        public static Characters current_user {  get; set; }
        public static string cur_username { get; set; }

        public static bool isadmin { get; set; }

    }
}
