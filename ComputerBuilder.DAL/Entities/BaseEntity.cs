using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerBuilder.DAL.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
