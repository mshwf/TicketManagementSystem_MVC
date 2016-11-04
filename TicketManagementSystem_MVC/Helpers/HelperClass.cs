using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TicketManagementSystem_MVC.Helper
{
    public class HelperClass
    {
        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            if (length < 4)
                length = 4;
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

    }
}