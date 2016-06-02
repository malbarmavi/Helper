namespace Helper.Models.SystemInfo
{
  public class Bios
  {
    public string Name { get; set; }

    //public string BIOSVersion { get; set; }
    public string BuildNumber { get; set; }

    public string CurrentLanguage { get; set; }
    public string InstallableLanguages { get; set; }
    public string ListOfLanguages { get; set; }
    public string Manufacturer { get; set; }
    public string PrimaryBios { get; set; }
    public string ReleaseDate { get; set; }
    public string SerialNumber { get; set; }

    //public string BiosVersion { get; set; }
    //public string BiosMajorVersion { get; set; }
    //public string BiosMinorVersion { get; set; }
    public string Version { get; set; }
  }
}