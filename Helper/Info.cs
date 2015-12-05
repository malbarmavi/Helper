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
        public DateTime InstallDate { get; set; }
        public DateTime LastRestart { get; set; }
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
            ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from Win32_Account");

            foreach (ManagementObject managmentObj in managmentSearcher.Get())
            {
                var os = new OperatingSystem();
                // get the data
                result.Add(os);

            }
            return result;
        }

    }
}
