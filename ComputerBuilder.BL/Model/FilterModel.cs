namespace ComputerBuilder.BL.Model
{
    public class FilterModel
    {
        public bool ManufacturerSelect { get; set; } = false;
        public string ManufacturerName { get; set; }

        public bool HardwareTypeSelect { get; set; } = false;
        public string HardwareTypeName {get; set;}
    }
}
