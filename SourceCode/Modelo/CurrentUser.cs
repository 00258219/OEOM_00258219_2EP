using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SourceCode.Modelo
{
    public static class CurrentUser
    {
        private static User user;
        public static User User
        {
            get => user;
            set => user = value;
        }
        
        private static List<string> usersname = new List<string>();
        public static List<string> Usersname => usersname;
        public static void AddUsername(string s)
        {
            usersname.Add(s);
        }
        
        
        // private static string user;
        // public static string User
        // {
        //     get => user;
        //     set => user = value;
        // }
        //
        // private static int id;
        // public static int Id
        // {
        //     get => id;
        //     set => id = value;
        // }
        //
        // private static string fullname;
        // public static string Fullname
        // {
        //     get => fullname;
        //     set => fullname = value;
        // }
        //
        // private static string password;
        // public static string Password
        // {
        //     get => password;
        //     set => password = value;
        // }
        //
        // private static bool admin;
        // public static bool Admin
        // {
        //     get => admin;
        //     set => admin = value;
        // }
        //
        // private static List<int> address;
        // public static List<int> Address => address;
        // public static void addAddres(int val)
        // {
        //     address.Add(val);
        // }

    }
}