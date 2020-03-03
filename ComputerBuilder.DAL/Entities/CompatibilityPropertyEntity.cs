using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuilder.DAL.Entities
{
    public class CompatibilityPropertyEntity : BaseEntity
    {
        /// <summary>
        /// Название характеристики
        /// </summary>
        [StringLength(50)]
        public string PropertyName { get; set; }
        /// <summary>
        /// Тип характеристики
        /// </summary>
        //[StringLength(50)]
        public string PropertyType { get; set; }
        /// <summary>
        /// Железка с такими свойствами
        /// </summary>
        public ICollection<CompatibilityPropertyHardwareItem> PropertiesItems { get; set; }

        public CompatibilityPropertyEntity() { }
        public CompatibilityPropertyEntity (string propertyType, string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                name="Не определён";
            }
            if (string.IsNullOrWhiteSpace(propertyType))
            {
                throw new ArgumentNullException("Название типа характеристики должно быть заполнено", nameof(propertyType));
            }
            PropertyName = name;
            PropertyType = propertyType;
            PropertiesItems = new List<CompatibilityPropertyHardwareItem>();
        }
        public override string ToString()
        {
            return PropertyType + " - " +PropertyName;
        }
    }
}