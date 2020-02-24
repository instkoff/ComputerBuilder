﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerBuilder.DAL.Entities
{
    public class ComputerBuild
    {
        public int Id { get; set; }
        /// <summary>
        /// Общая сумма сборки
        /// </summary>
        public double TotalCost { get; set; }
        /// <summary>
        /// Дата создания сборки
        /// </summary>
        public DateTime BuildDate { get; set; }
        /// <summary>
        /// Название сборки
        /// </summary>
        //[StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// Описание сборки
        /// </summary>
        [StringLength(255)]
        public string Description { get; set; } = " ";
        /// <summary>
        /// Список комплектующих
        /// </summary>
        public ICollection<BuildItem> BuildItems { get; set; }

        public ComputerBuild() { }
        public ComputerBuild(string name, string description)
        {
            #region Проверки
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название сборки должно быть заполнено", nameof(name));
            }
            #endregion
            Name = name;
            Description = description;
            BuildDate = DateTime.Now;
            BuildItems = new List<BuildItem>();
            TotalCost = 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
