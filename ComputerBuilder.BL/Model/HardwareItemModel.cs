using System.Collections.Generic;

namespace ComputerBuilder.BL.Model
{
    public class HardwareItemModel
    {
        #region Свойства
        /// <summary>
        /// Название железки
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цена железки
        /// </summary>
        public double Cost { get; set; }
        /// <summary>
        /// Описание других характеристик
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Производитель
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Тип железа
        /// </summary>
        public string HardwareType { get; set; }
        /// <summary>
        /// Список характеристик железки
        /// </summary>
        public List<CompatibilityPropertyModel> PropertyList { get; set; }
        #endregion
    }
}
