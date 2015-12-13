using System;
using System.Collections.Generic;
using System.Management;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class OperatingSystem
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Architecture { get; set; }
        public DateTime? InstallDate { get; set; }
        public DateTime? LastRestart { get; set; }
        public string ProductType { get; set; }
        public string PrimaryOS { get; set; }
        public string SerialNumber { get; set; }
        public string RegisteredUser { get; set; }
        public string Organization { get; set; }
        public string BootDevice { get; set; }
        public string SystemDevice { get; set; }
        public string SystemDrive { get; set; }
        public string WindowsDirectory { get; set; }
        public string SystemDirectory { get; set; }


    }

    public class UsersAccounts
    {
        public string Name { get; set; }
        public string AcountType { get; set; }
        public string Description { get; set; }
        public string Disabled { get; set; }
        public string LocalAccount { get; set; }
        public string Lockout { get; set; }
        public string PasswordChangeable { get; set; }
        public string PasswordExpires { get; set; }
        public string PasswordRequired { get; set; }
        public string SecuirtyIdentifier { get; set; }
        public string SecuirtyIdentiferType { get; set; }
        public string Status { get; set; }
    }
    public class SystemAccounts
    {


    }

    public class Groups
    {

    }

    public class CPU
    {

    }

    public class Memory
    {

    }
    //disk drive
    public class StorageDrives
    {

    }

    public class DiskPartions { }
    public class LogicalDisks { }
    public class MotherBoard { }
    public class BIOS { }

    public static class SysyemInfo
    {
        public static List<OperatingSystem> GetOperatingSystems()
        {
            var result = new List<OperatingSystem>();
            ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            foreach (ManagementObject managmentObj in managmentSearcher.Get())
            {
                var os = new OperatingSystem();
                os.Name = GetValue(managmentObj.Properties["Caption"].Value);
                os.Version = String.Format("{0} {1} {2}",
                    GetValue(managmentObj.Properties["OSType"].Value, GetOSType),
                    GetValue(managmentObj.Properties["Version"].Value),
                    GetValue(managmentObj.Properties["CSDVersion"].Value));
                os.Architecture = GetValue(managmentObj.Properties["Caption"].Value).Equals("64-bit") ? "64-bit Operating System " : "32-bit Operating System";
                os.InstallDate = GetDate(managmentObj.Properties["InstallDate"].Value);
                os.LastRestart = GetDate(managmentObj.Properties["LastBootUpTime"].Value);
                os.ProductType = GetValue(managmentObj.Properties["ProductType"].Value, GetProductType);
                os.PrimaryOS = GetValue(managmentObj.Properties["Primary"].Value) == "True" ? "Yes" : "No";
                os.SerialNumber = GetValue(managmentObj.Properties["SerialNumber"].Value);
                os.RegisteredUser = GetValue(managmentObj.Properties["RegisteredUser"].Value);
                os.Organization = GetValue(managmentObj.Properties["Organization"].Value);
                os.BootDevice = GetValue(managmentObj.Properties["BootDevice"].Value);
                os.SystemDevice = GetValue(managmentObj.Properties["SystemDevice"].Value);
                os.SystemDrive = GetValue(managmentObj.Properties["SystemDrive"].Value);
                os.WindowsDirectory = GetValue(managmentObj.Properties["WindowsDirectory"].Value);
                os.SystemDirectory = GetValue(managmentObj.Properties["SystemDirectory"].Value);
                result.Add(os);
            }
            return result;
        }
        public static List<UsersAccounts> GetUserAccounts()
        {
            var result = new List<UsersAccounts>();
            ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from Win32_UserAccount");
            foreach (ManagementObject managmentObj in managmentSearcher.Get())
            {
                var userAccount = new UsersAccounts();
                userAccount.Name = GetValue(managmentObj.Properties["Name"].Value);
                userAccount.AcountType = GetValue(managmentObj.Properties["AccountType"].Value, GetAccontType);
                userAccount.Description = GetValue(managmentObj.Properties["Description"].Value);
                userAccount.Disabled = GetValue(managmentObj.Properties["Disabled"].Value);
                userAccount.LocalAccount = GetValue(managmentObj.Properties["LocalAccount"].Value);
                userAccount.Lockout = GetValue(managmentObj.Properties["Lockout"].Value);
                userAccount.PasswordChangeable = GetValue(managmentObj.Properties["PasswordChangeable"].Value);
                userAccount.PasswordExpires = GetValue(managmentObj.Properties["PasswordExpires"].Value);
                userAccount.PasswordRequired = GetValue(managmentObj.Properties["PasswordRequired"].Value);
                userAccount.SecuirtyIdentifier = GetValue(managmentObj.Properties["SID"].Value);
                userAccount.SecuirtyIdentiferType = GetValue(managmentObj.Properties["SIDType"].Value, GetSecurityIdentiferType);
                userAccount.Status = GetValue(managmentObj.Properties["Status"].Value);


                result.Add(userAccount);
            }


            return result;
        }
        private static string GetValue(object value)
        {
            try
            {
                return Convert.ToString(value);

            }
            catch (Exception)
            {
                return "";

            }
        }
        private static DateTime? GetDate(object value)
        {

            var date = GetValue(value);
            if (!date.IsNullOrEmptyOrWhiteSpacce())
            {
                return ManagementDateTimeConverter.ToDateTime(date);
            }

            return null;
        }
        private static string GetValue(object value, Func<string, string> ResultFormater)
        {
            var result = GetValue(value);

            if (result != string.Empty)
            {
                result = ResultFormater(result);
            }

            return result;
        }
        private static string GetOSType(string type)
        {
            var result = string.Empty;
            switch (type)
            {
                case "14":
                    result = "MS-DOS";
                    break;
                case "15":
                    result = "Windows 3x";
                    break;
                case "16":
                    result = "Windows 95";
                    break;
                case "17":
                    result = "Windows 98";
                    break;
                case "18":
                    result = "Windows NT";
                    break;
                case "19":
                    result = "Windows CE";
                    break;
                default:
                    result = "";
                    break;

            }
            return result;
        }
        private static string GetProductType(string type)
        {
            return (type == "1") ? "Work Station" : (type == "2") ? "Domain Controller" : (type == "3") ? "Server" : " ";
        }
        private static string GetAccontType(string type)
        {
            string result = string.Empty;

            switch (type)
            {
                case "256":
                    result = "Temp Duplicate AccountT";
                    break;
                case "512":
                    result = "Normal Account";
                    break;
                case "2048":
                    result = "Interdomain Trust Account";
                    break;
                case "4096":
                    result = "Workstation Trust Account";
                    break;
                case "8192":
                    result = "Server Trust account";
                    break;

                default:
                    break;
            }
            return result;
        }
        private static string GetSecurityIdentiferType(string type)
        {
            string result = String.Empty;
            switch (type)
            {
                case "1":
                    result = "User";
                    break;
                case "2":
                    result = "Group";
                    break;
                case "3":
                    result = "Domain";
                    break;
                case "4":
                    result = "Alias";
                    break;
                case "5":
                    result = "Well Known Group";
                    break;
                case "6":
                    result = "Deleted Account";
                    break;
                case "7":
                    result = "Invalid";
                    break;
                case "8":
                    result = "Unknown";
                    break;
                case "9":
                    result = "Computer";
                    break;
            }
            return result;
        }
    }


}

