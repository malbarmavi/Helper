namespace Helper.Models.SystemInfo
{
    public class DiskPartition
    {
        public string Name { get; set; }
        public string BlockSize { get; set; }
        public string Bootable { get; set; }
        public string BootPartition { get; set; }
        public string Type { get; set; }
        public string DeviceID { get; set; }
        public string DiskIndex { get; set; }
        public string Index { get; set; }
        public string NumberOfBlocks { get; set; }
        public string PrimaryPartition { get; set; }
        public string Size { get; set; }
    }
}