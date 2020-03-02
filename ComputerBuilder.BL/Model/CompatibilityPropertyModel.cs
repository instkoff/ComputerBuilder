using System;

namespace ComputerBuilder.BL.Model
{
    public class CompatibilityPropertyModel
    {
        /// <summary>
        /// Название характеристики
        public string PropertyName { get; set; }
        /// <summary>
        /// Тип характеристики
        /// </summary>
        //[StringLength(50)]
        public string PropertyType { get; set; }
        /// <summary>
        /// Железка с такими свойствами
        /// </summary>
    }
}