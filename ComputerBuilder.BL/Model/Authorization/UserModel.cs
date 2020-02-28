using System.Collections.Generic;

namespace ComputerBuilder.BL.Model.Authorization
{
    public class UserModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public List<ComputerBuildModel> ComputerBuildCollection { get; set; }
    }
}
