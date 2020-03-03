namespace ComputerBuilder.DAL.Entities
{
    public class CompatibilityPropertyHardwareItem
    {
        public int HardwareItemId { get; set; }
        public HardwareItemEntity HardwareItem { get; set; }
        public int CompatibilityPropertyId { get; set; }
        public CompatibilityPropertyEntity CompatibilityProperty { get; set; }
    }
}
