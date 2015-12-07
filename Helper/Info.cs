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

    }
}
