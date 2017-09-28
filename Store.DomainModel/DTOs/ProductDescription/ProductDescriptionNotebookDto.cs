namespace Store.DomainModel.DTOs.ProductDescription
{
    public class ProductDescriptionNotebookDto : ProductDescriptionBaseDto
    {
        public bool IsTransformer { get; set; }
        public string PlatformOrCodeName { get; set; }
        public string Cpu { get; set; }
        public string ProcessorModel { get; set; }
        public sbyte NumberOfCores { get; set; }
        public decimal ClockFrequencyMhz { get; set; }
        public decimal? TurboFrequency { get; set; }
        // CPU power consumption
        public decimal? Tdp { get; set; }
        public string CoverColor { get; set; }
        public string IlluminationOfCase { get; set; }
        public sbyte ScreenDiagonal { get; set; }
        public decimal ScreenResolutionWidth { get; set; }
        public decimal ScreenResolutionHeight { get; set; }
        public string ScreenTechnology { get; set; }
        public string TypeOfRam { get; set; }
        public short RamSizeGb { get; set; }
        public string[] TypeOfDrive { get; set; }
        public decimal HardDriveCapacityGb { get; set; }
        public decimal? SsdCapacityGb { get; set; }
        public string GraphicAdapter { get; set; }
        public string TypeOfGraphicsAdapter { get; set; }
        public string BuiltInCamera { get; set; }
        public string BuiltInMicrophone { get; set; }
        public string BuiltInSpeakers { get; set; }
        public string FingerprintScanner { get; set; }
        public string Nfc { get; set; }
        public string Bluetooth { get; set; }
        public string Lan { get; set; }
        public string WiFi { get; set; }
        public sbyte CountUsb2 { get; set; }
        public sbyte CountUsb3 { get; set; }
        public sbyte CountHdmi { get; set; }
        public string AudioOutputs { get; set; }
        public sbyte? BatteryLifeTimeHours { get; set; }
        public string OperatingSystem { get; set; }
    }
}
