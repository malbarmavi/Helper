using System;
using System.Collections.Generic;
using System.Management;

namespace Helper
{
    using Model.SystemInfo;

    public static class SystemInfo
    {
        public static List<OperatingSystem> GetOperatingSystems()
        {
            var result = new List<OperatingSystem>();
            ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            foreach (ManagementObject managmentObj in managmentSearcher.Get())
            {
                var os = new OperatingSystem();
                os.Name = GetValue(managmentObj.Properties["Caption"].Value);
                os.Version = $"{GetValue(managmentObj.Properties["OSType"].Value, OSTypeFormater)} {GetValue(managmentObj.Properties["Version"].Value)} {GetValue(managmentObj.Properties["CSDVersion"].Value)}";
                os.Architecture = GetValue(managmentObj.Properties["Caption"].Value).Equals("64-bit") ? "64-bit Operating System " : "32-bit Operating System";
                os.InstallDate = GetDate(managmentObj.Properties["InstallDate"].Value);
                os.LastRestart = GetDate(managmentObj.Properties["LastBootUpTime"].Value);
                os.ProductType = GetValue(managmentObj.Properties["ProductType"].Value, ProductFormater);
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
                userAccount.AcountType = GetValue(managmentObj.Properties["AccountType"].Value, AccontTypeFormater);
                userAccount.Description = GetValue(managmentObj.Properties["Description"].Value);
                userAccount.Disabled = GetValue(managmentObj.Properties["Disabled"].Value);
                userAccount.LocalAccount = GetValue(managmentObj.Properties["LocalAccount"].Value);
                userAccount.Lockout = GetValue(managmentObj.Properties["Lockout"].Value);
                userAccount.PasswordChangeable = GetValue(managmentObj.Properties["PasswordChangeable"].Value);
                userAccount.PasswordExpires = GetValue(managmentObj.Properties["PasswordExpires"].Value);
                userAccount.PasswordRequired = GetValue(managmentObj.Properties["PasswordRequired"].Value);
                userAccount.SecuirtyIdentifier = GetValue(managmentObj.Properties["SID"].Value);
                userAccount.SecuirtyIdentiferType = GetValue(managmentObj.Properties["SIDType"].Value, SecurityIdentiferTypeFormater);
                userAccount.Status = GetValue(managmentObj.Properties["Status"].Value);


                result.Add(userAccount);
            }


            return result;
        }
        public static List<SystemAccounts> GetSystemAccounts()
        {
            var result = new List<SystemAccounts>();
            ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from Win32_SystemAccount");
            foreach (ManagementObject managmentObj in managmentSearcher.Get())
            {
                var sysAccounts = new SystemAccounts();
                sysAccounts.Name = GetValue(managmentObj.Properties["Name"].Value);
                sysAccounts.Domain = GetValue(managmentObj.Properties["Domain"].Value);
                sysAccounts.LocalAccount = GetValue(managmentObj.Properties["LocalAccount"].Value);
                sysAccounts.SecurityIdentifier = GetValue(managmentObj.Properties["SID"].Value);
                sysAccounts.SecurityIdentifierType = GetValue(managmentObj.Properties["SIDType"].Value, SecurityIdentiferTypeFormater);
                sysAccounts.State = GetValue(managmentObj.Properties["Status"].Value);
                result.Add(sysAccounts);
            }
            return result;
        }

        public static List<UsersGroups> GetUsersGroups()
        {
            List<UsersGroups> result = new List<UsersGroups>();
            using (ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from Win32_SystemAccount"))
            {
                foreach (ManagementObject managmentObj in managmentSearcher.Get())
                {
                    var userGroup = new UsersGroups();
                    userGroup.Name = GetValue(managmentObj.Properties["Name"].Value);
                    userGroup.Domain = GetValue(managmentObj.Properties["Domain"].Value);
                    userGroup.LocalAccount = GetValue(managmentObj.Properties["LocalAccount"].Value);
                    userGroup.SecurityIdentifier = GetValue(managmentObj.Properties["SID"].Value);
                    userGroup.SecurityIdentifierType = GetValue(managmentObj.Properties["SIDType"].Value, SecurityIdentiferTypeFormater);
                    userGroup.State = GetValue(managmentObj.Properties["Status"].Value);
                    result.Add(userGroup);
                }
            }

            return result;
        }

        public static List<CPU> GetCPU()
        {
            var result = new List<CPU>();
            ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject managmentObj in managmentSearcher.Get())
            {
                var cpu = new CPU();

                cpu.Name = GetValue(managmentObj.Properties["Name"].Value);
                cpu.AddressWidth = GetValue(managmentObj.Properties["AddressWidth"].Value);
                cpu.Architecture = GetValue(managmentObj.Properties["Architecture"].Value);
                cpu.Model = GetValue(managmentObj.Properties["Caption"].Value);
                cpu.CurrentClockSpeed = GetValue(managmentObj.Properties["CurrentClockSpeed"].Value, SpeedFormater);
                cpu.CurrentVoltage = GetValue(managmentObj.Properties["CurrentVoltage"].Value);
                cpu.DataWidth = GetValue(managmentObj.Properties["DataWidth"].Value);
                cpu.DeviceId = GetValue(managmentObj.Properties["DeviceID"].Value);
                cpu.ExtClock = GetValue(managmentObj.Properties["ExtClock"].Value);
                cpu.Family = GetValue(managmentObj.Properties["Family"].Value);
                cpu.L2ChacheSize = GetValue(managmentObj.Properties["L2CacheSize"].Value, MBFormater);
                cpu.L3ChacheSize = GetValue(managmentObj.Properties["L3CacheSize"].Value, MBFormater);
                cpu.Manufacturer = GetValue(managmentObj.Properties["Manufacturer"].Value);
                cpu.Speed = GetValue(managmentObj.Properties["MaxClockSpeed"].Value, MBFormater);
                cpu.Cores = GetValue(managmentObj.Properties["NumberOfCores"].Value);
                cpu.LogicalProcessor = GetValue(managmentObj.Properties["NumberOfLogicalProcessors"].Value);
                cpu.ProcessorId = GetValue(managmentObj.Properties["ProcessorId"].Value);
                cpu.ProcessorType = GetValue(managmentObj.Properties["ProcessorType"].Value);
                cpu.Revision = GetValue(managmentObj.Properties["Revision"].Value);
                cpu.SocketDesignation = GetValue(managmentObj.Properties["SocketDesignation"].Value);

                result.Add(cpu);

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
            if (date.IsValidString())
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


        // Formater Section 
        private static string OSTypeFormater(string type)
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
        private static string ProductFormater(string type)
            => (type == "1") ? "Work Station" : (type == "2") ? "Domain Controller" : (type == "3") ? "Server" : " ";
        private static string AccontTypeFormater(string type)
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
        private static string SecurityIdentiferTypeFormater(string type)
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
        private static string SpeedFormater(string speed) => $"{double.Parse(speed) / 1000} GHz";
        private static string KBFormater(string size) => $"{size} Kb";
        private static string MBFormater(string size) => $"{double.Parse(size) / 1024} Mb";

    }


}

