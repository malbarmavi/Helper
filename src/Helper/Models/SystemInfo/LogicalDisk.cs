namespace Helper.Models.SystemInfo
{
    public class LogicalDisks
    {
        public string Name { get; set; }
        public string Access { get; set; }
        public string Compressed { get; set; }
        public string Description { get; set; }
        public string DeviceId { get; set; }
        public string DriveType { get; set; }
        public string FileSystem { get; set; }
        public string FreeSpace { get; set; }
        public string Size { get; set; }
        public string VolumeName { get; set; }
        public string VolumeSerialNumber { get; set; }
    }
}