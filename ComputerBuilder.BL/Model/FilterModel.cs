namespace ComputerBuilder.BL.Model
{
    public class FilterModel
    {
        public bool ManufacturerCheck { get; set; } = false;
        public string ManufacturerName { get; set; }

        public bool HardwareTypeCheck { get; set; } = false;
        public string HardwareTypeName {get; set; }

        public bool HardwarePropertiesCheck { get; set; } = false;
        public CompatibilityPropertyModel HardwareProperties { get; set; }
    }
}
