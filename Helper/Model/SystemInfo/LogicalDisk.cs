using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Model.SystemInfo
{
    public class LogicalDisk
    {
        public string Name { get; set; }
        public string Access { get; set; }
        public string Compressed { get; set; }
        public string Description { get; set; }
        public string DeviceID { get; set; }
        public string DriveType { get; set; }
        public string FileSystem { get; set; }
        public string FreeSpace { get; set; }
        public string MediaType { get; set; }
        public string Size { get; set; }
        public string VolumeName { get; set; }
        public string VolumeSerialNumber { get; set; }
    }
}
