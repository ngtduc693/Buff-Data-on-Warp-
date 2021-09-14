using System;
using WARP_Buff.Services;

namespace WARP_Buff
{
    public class Program
    {
        static void Main(string[] args)
        {
            string userID = "";
            var account = new AccountService();
            Console.WriteLine("[+] CREATED BY NGTDUC693");
            Console.WriteLine("[-] With this tool, you can getting unlimited GB on Warp+.");            
            do
            {
                Console.Write("[-] Input your user ID: ");
                userID = Console.ReadLine();
                if (userID.Trim().Length == 0)
                    Console.WriteLine("[+] Your user ID is not valid, please try again!");
            }
            while (userID.Trim().Length <= 0);
            account.BuffData(userID);
        }
    }
}
