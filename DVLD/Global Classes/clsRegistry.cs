using System;
using Microsoft.Win32;

namespace DVLD.Classes
{
    public class clsRegistry
    {

        private static string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLDApp";
        private static string ValueName = "LoginInfo";
      
        
        /// <summary>
        /// This static Method Save Username and Password for Current User in Value'LoginInfo' in Windows Registry
        /// </summary>
        /// <param name="UserName">Username value</param>
        /// <param name="Password">Password value</param>
        /// <returns>boolin value True or False</returns>
        public static bool StoreLogInRegistry(string UserName,string Password)
        {
            
            string ValueData = UserName.Trim() +"#//#"+ Password.Trim();
            try
            {
                Registry.SetValue(KeyPath, ValueName, ValueData);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }


        }
      
        
        /// <summary>
        /// Retriveing the Username and Password for Current User in Value'LoginInfo' in Windows Registry
        /// </summary>
        /// <param name="Username">Username value</param>
        /// <param name="Password">Password value</param>
        /// <returns>boolin value True or False</returns>
        public static bool GetLoginInfo(ref string Username,ref string Password)
        {
            try
            {
                string ValueData = Registry.GetValue(KeyPath, ValueName, null) as string;

                if (ValueData != null)
                {
                    string[] values = ValueData.Split(new string[] { "#//#" }, StringSplitOptions.None);
                    Username = values[0];
                    Password = values[1];

                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
       
        
        /// <summary>
        /// This Method Delete LoginInfo Value in Registry.
        /// </summary>
        /// <returns>boolin value True or False</returns>
        public static bool DeleteLoginInfo()
        {
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\DVLDApp", true))
                    {
                        if (key != null)
                        {
                            // Delete the specified value
                            key.DeleteValue(ValueName);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }    

    }
}
