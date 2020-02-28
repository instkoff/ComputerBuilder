using System.Collections.Generic;

namespace ComputerBuilder.DAL.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<ComputerBuildEntity> ComputerBuildCollection { get; set; }
    }
}
