using ComputerBuilder.DAL.Entities;
using System;
using System.Collections.Generic;

namespace ComputerBuilder.BL.Model
{
    public class ComputerBuildModel
    {
        /// <summary>
        /// Название сборки
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата создания сборки
        /// </summary>
        public DateTime BuildDate { get; set; }
        /// <summary>
        /// Общая сумма сборки
        /// </summary>
        public double TotalCost { get; set; }
        /// <summary>
        /// Описание сборки
        /// </summary>
        public string Description { get; set; } = " ";
        /// <summary>
        /// Список комплектующих
        /// </summary>
        public List<HardwareItemModel> HardwareItemsList { get; set; }
    }
}
