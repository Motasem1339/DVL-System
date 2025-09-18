using System;
using System.Text;
using System.Security.Cryptography;

namespace DVLD_DataAccess
{
    public class clsCrypt
    {

        public static string CopmuteHash(string Input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] HashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Input));

                return BitConverter.ToString(HashBytes).Replace("-", "").ToLower();
            }
        }

    }
}
