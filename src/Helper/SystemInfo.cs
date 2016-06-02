using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace Helper
{
  using Extention;
  using Models.SystemInfo;

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

    public static List<Cpu> GetCPU()
    {
      var result = new List<Cpu>();
      ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from Win32_Processor");
      foreach (ManagementObject managmentObj in managmentSearcher.Get())
      {
        var cpu = new Cpu();
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
        cpu.Speed = GetValue(managmentObj.Properties["MaxClockSpeed"].Value, SpeedFormater);
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

    public static List<Memory> GetMemory()
    {
      var result = new List<Memory>();
      ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from Win32_PhysicalMemory");
      foreach (ManagementObject managmentObj in managmentSearcher.Get())
      {
        Memory memory = new Memory();
        memory.BankLabel = GetValue(managmentObj.Properties["BankLabel"].Value);
        memory.Capacity = GetValue(managmentObj.Properties["Capacity"].Value, GBFormater);
        memory.DataWidth = GetValue(managmentObj.Properties["DataWidth"].Value);
        memory.DeviceLocator = GetValue(managmentObj.Properties["DeviceLocator"].Value);
        memory.FormFactor = GetValue(managmentObj.Properties["FormFactor"].Value);
        memory.InterleaveDataDepth = GetValue(managmentObj.Properties["InterleaveDataDepth"].Value);
        memory.Manufacturer = GetValue(managmentObj.Properties["Manufacturer"].Value);
        memory.MemoryType = GetValue(managmentObj.Properties["MemoryType"].Value);
        memory.PartNumber = GetValue(managmentObj.Properties["PartNumber"].Value);
        memory.SerialNumber = GetValue(managmentObj.Properties["SerialNumber"].Value);
        memory.Speed = GetValue(managmentObj.Properties["Speed"].Value);
        memory.Tag = GetValue(managmentObj.Properties["Tag"].Value);
        memory.TotalWidth = GetValue(managmentObj.Properties["TotalWidth"].Value);
        memory.TypeDetail = GetValue(managmentObj.Properties["TypeDetail"].Value);
        result.Add(memory);
      }
      return result;
    }

    public static List<DiskDrive> GetDiskDrives()
    {
      List<DiskDrive> result = new List<DiskDrive>();

      ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from win32_DiskDrive");
      foreach (ManagementObject managmentObj in managmentSearcher.Get())
      {
        DiskDrive diskDrive = new DiskDrive();

        diskDrive.Availability = GetValue(managmentObj.Properties["Availability"].Value);
        diskDrive.BytesPerSector = GetValue(managmentObj.Properties["BytesPerSector"].Value);
        diskDrive.Capability = GetValue(managmentObj.Properties["CapabilityDescriptions"].Value, StringArrayFormater);
        diskDrive.Caption = GetValue(managmentObj.Properties["Caption"].Value);
        diskDrive.CompressionMethod = GetValue(managmentObj.Properties["CompressionMethod"].Value);
        diskDrive.DeviceId = GetValue(managmentObj.Properties["DeviceID"].Value);
        diskDrive.FirmwareRevision = GetValue(managmentObj.Properties["FirmwareRevision"].Value);
        diskDrive.InterfaceType = GetValue(managmentObj.Properties["InterfaceType"].Value);
        diskDrive.MediaLoaded = GetValue(managmentObj.Properties["MediaLoaded"].Value);
        diskDrive.MediaType = GetValue(managmentObj.Properties["MediaType"].Value);
        diskDrive.Model = GetValue(managmentObj.Properties["Model"].Value);
        diskDrive.Name = GetValue(managmentObj.Properties["Name"].Value);
        diskDrive.Partitions = GetValue(managmentObj.Properties["Partitions"].Value);
        diskDrive.PnpDeviceId = GetValue(managmentObj.Properties["PNPDeviceID"].Value);
        diskDrive.SerialNumber = GetValue(managmentObj.Properties["SerialNumber"].Value);
        diskDrive.Signature = GetValue(managmentObj.Properties["Signature"].Value);
        diskDrive.Size = GetValue(managmentObj.Properties["Size"].Value, HddSizeFormater);
        result.Add(diskDrive);
      }

      return result;
    }

    public static List<DiskPartition> GetDiskPartition()
    {
      List<DiskPartition> result = new List<DiskPartition>();

      ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from win32_DiskPartition");
      foreach (ManagementObject managmentObj in managmentSearcher.Get())
      {
        DiskPartition partition = new DiskPartition();
        partition.Name = GetValue(managmentObj.Properties["Name"].Value);
        partition.BlockSize = GetValue(managmentObj.Properties["BlockSize"].Value);
        partition.Bootable = GetValue(managmentObj.Properties["Bootable"].Value);
        partition.BootPartition = GetValue(managmentObj.Properties["BootPartition"].Value);
        partition.Type = GetValue(managmentObj.Properties["Type"].Value);
        partition.DeviceId = GetValue(managmentObj.Properties["DeviceID"].Value);
        partition.DiskIndex = GetValue(managmentObj.Properties["DiskIndex"].Value);
        partition.Index = GetValue(managmentObj.Properties["Index"].Value);
        partition.NumberOfBlocks = GetValue(managmentObj.Properties["NumberOfBlocks"].Value);
        partition.PrimaryPartition = GetValue(managmentObj.Properties["PrimaryPartition"].Value);
        partition.Size = GetValue(managmentObj.Properties["Size"].Value, GBFormater);

        result.Add(partition);
      }
      return result;
    }

    public static List<LogicalDisks> GetLogicalDisks()
    {
      List<LogicalDisks> result = new List<LogicalDisks>();

      ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from win32_LogicalDisk");
      foreach (ManagementObject managmentObj in managmentSearcher.Get())
      {
        LogicalDisks logicalDisk = new LogicalDisks();

        logicalDisk.Name = GetValue(managmentObj.Properties["Name"].Value);
        logicalDisk.Access = GetValue(managmentObj.Properties["Access"].Value);
        logicalDisk.Compressed = GetValue(managmentObj.Properties["Compressed"].Value);
        logicalDisk.Description = GetValue(managmentObj.Properties["Description"].Value);
        logicalDisk.DeviceId = GetValue(managmentObj.Properties["DeviceID"].Value);
        logicalDisk.DriveType = GetValue(managmentObj.Properties["DriveType"].Value, DriverTypeFormatter);
        logicalDisk.FileSystem = GetValue(managmentObj.Properties["FileSystem"].Value);
        logicalDisk.FreeSpace = GetValue(managmentObj.Properties["FreeSpace"].Value, GBFormater);
        logicalDisk.Size = GetValue(managmentObj.Properties["Size"].Value, GBFormater);
        logicalDisk.VolumeName = GetValue(managmentObj.Properties["VolumeName"].Value);
        logicalDisk.VolumeSerialNumber = GetValue(managmentObj.Properties["VolumeSerialNumber"].Value);

        result.Add(logicalDisk);
      }
      return result;
    }

    public static MotherBoard GetMotherBoard()
    {
      MotherBoard mb = new MotherBoard();
      ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from win32_baseBoard");
      ManagementObject managmentObj = managmentSearcher.Get().Cast<ManagementObject>().First();

      mb.Name = GetValue(managmentObj.Properties["Name"].Value);
      mb.Description = GetValue(managmentObj.Properties["Description"].Value);
      mb.HostingBoard = GetValue(managmentObj.Properties["HostingBoard"].Value);
      mb.HotSwappable = GetValue(managmentObj.Properties["HotSwappable"].Value);
      mb.Manufacturer = GetValue(managmentObj.Properties["Manufacturer"].Value);
      mb.PartNumber = GetValue(managmentObj.Properties["PartNumber"].Value);
      mb.PoweredOn = GetValue(managmentObj.Properties["PoweredOn"].Value);
      mb.Removable = GetValue(managmentObj.Properties["Removable"].Value);
      mb.Replaceable = GetValue(managmentObj.Properties["Replaceable"].Value);
      mb.SerialNumber = GetValue(managmentObj.Properties["SerialNumber"].Value);
      mb.Version = GetValue(managmentObj.Properties["Version"].Value);

      return mb;
    }

    public static Bios GetBios()
    {
      Bios bios = new Bios();
      ManagementObjectSearcher managmentSearcher = new ManagementObjectSearcher("select * from win32_BIOS");
      ManagementObject managmentObj = managmentSearcher.Get().Cast<ManagementObject>().First();
      bios.Name = GetValue(managmentObj.Properties["Name"].Value);
      //bios.BIOSVersion = GetValue(managmentObj.Properties["BIOSVersion"].Value, StringArrayFormater);
      bios.BuildNumber = GetValue(managmentObj.Properties["BuildNumber"].Value);
      bios.CurrentLanguage = GetValue(managmentObj.Properties["CurrentLanguage"].Value);
      bios.InstallableLanguages = GetValue(managmentObj.Properties["InstallableLanguages"].Value);
      bios.ListOfLanguages = GetValue(managmentObj.Properties["ListOfLanguages"].Value);
      bios.Manufacturer = GetValue(managmentObj.Properties["Manufacturer"].Value);
      bios.PrimaryBios = GetValue(managmentObj.Properties["PrimaryBIOS"].Value);
      bios.ReleaseDate = GetDate(managmentObj.Properties["ReleaseDate"].Value).Value.ToString();
      bios.SerialNumber = GetValue(managmentObj.Properties["SerialNumber"].Value);
      //bios.BiosVersion = GetValue(managmentObj.Properties["SMBIOSBIOSVersion"].Value);
      //bios.BiosMajorVersion = GetValue(managmentObj.Properties["SMBIOSMajorVersion"].Value);
      //bios.BiosMinorVersion = GetValue(managmentObj.Properties["SMBIOSMinorVersion"].Value);
      bios.Version = $"{GetValue(managmentObj.Properties["Version"].Value)} {GetValue(managmentObj.Properties["SMBIOSBIOSVersion"].Value)}";

      return bios;
    }

    #region Methods

    private static string GetValue(object value)
    {
      try
      {
        return Convert.ToString(value) ?? string.Empty;
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

    private static string GetValue(object value, Func<object, string> ResultFormater) => ResultFormater(value);

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
      switch (type)
      {
        case "256":
          return "Temp Duplicate AccountT";

        case "512":
          return "Normal Account";

        case "2048":
          return "Interdomain Trust Account";

        case "4096":
          return "Workstation Trust Account";

        case "8192":
          return "Server Trust account";

        default:
          return string.Empty;
      }
    }

    private static string SecurityIdentiferTypeFormater(string type)
    {
      switch (type)
      {
        case "1":
          return "User";

        case "2":
          return "Group";

        case "3":
          return "Domain";

        case "4":
          return "Alias";

        case "5":
          return "Well Known Group";

        case "6":
          return "Deleted Account";

        case "7":
          return "Invalid";

        case "8":
          return "Unknown";

        case "9":
          return "Computer";

        default:
          return "";
      }
    }

    private static string SpeedFormater(string speed) => $"{double.Parse(speed) / 1000} GHz";

    private static string KBFormater(string size) => $"{size} KB";

    private static string MBFormater(string size) => $"{double.Parse(size) / 1024} MB";

    private static string GBFormater(string size) => $"{(double.Parse(size) / 1024 / 1024 / 1024).ToString("#.00") } GB";

    private static string HddSizeFormater(string size) => $"{(double.Parse(size) / 1000 / 1000 / 1000).ToString("#") } GB";

    private static string StringArrayFormater(object value) => (value as string[]) != null ? string.Join(" , ", (value as string[])) : string.Empty;

    private static string DriverTypeFormatter(string value)
    {
      switch (value)
      {
        case "0":
          return "Unknown";

        case "1":
          return "No Root Directory";

        case "2":
          return "Removable Disk";

        case "3":
          return "Local Disk";

        case "4":
          return "Network Drive";

        case "5":
          return "Compact Disc";

        case "6":
          return "RAM Disk";

        default:
          return string.Empty;
      }
    }

    #endregion Methods
  }
}