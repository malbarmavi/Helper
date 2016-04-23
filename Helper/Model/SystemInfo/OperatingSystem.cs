using System;

namespace Helper.Model.SystemInfo
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
}