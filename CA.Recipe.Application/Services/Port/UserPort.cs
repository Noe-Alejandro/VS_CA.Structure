using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Recipe.Application.Services.Port
{
    public class UserRequest
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    public class UserResponse
    {
        public int id { get; set; }
        public string username { get; set; }
    }
    public class UserResponseDB
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int usertype { get; set; }
        public string password { get; set; }
    }
}
