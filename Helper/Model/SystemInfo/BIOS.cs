using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Model.SystemInfo
{
    public class BIOS
    {
        public string Name { get; set; }
        public string BiosCharacteristics { get; set; }
        public string BIOSVersion { get; set; }
        public string BuildNumber { get; set; }
        public string CurrentLanguage { get; set; }
        public string InstallableLanguages { get; set; }
        public string ListOfLanguages { get; set; }
        public string Manufacturer { get; set; }
        public string PrimaryBIOS { get; set; }
        public string ReleaseDate { get; set; }
        public string SerialNumber { get; set; }
        public string SMBIOSBIOSVersion { get; set; }
        public string SMBIOSMajorVersion { get; set; }
        public string Version { get; set; }

    }
}
