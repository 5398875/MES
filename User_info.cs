using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES
{
    public static class User_info
    {
        public static string User_name { get; set; }
        public static string User_position { get; set; }
        public static string User_connection = "Server=localhost;Port=3306;Database=mes;Uid=root;Pwd=1234;";
        //public static string User_connection = "Server=192.168.3.3;Port=3306;Database=mes;Uid=cn;Pwd=korcham1!;"
    }
}
